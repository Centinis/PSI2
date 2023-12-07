import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { TextField, Button, Typography, Container, Paper, CircularProgress } from '@mui/material';
import { resetPassword } from '../api/ResetPasswordAPI';
import { LoginContainerStyles } from '../styles/LoginContainerStyles.js';


const ResetPasswordPage = () => {
    const { token } = useParams();
    const [decodedToken, setDecodedToken] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const [processing, setProcessing] = useState(false);
    const [error, setError] = useState('');
    const [emailError, setEmailError] = useState('');
    const [resetSuccess, setResetSuccess] = useState(false);
    const navigate = useNavigate();

    useEffect(() => {
        const decoded = decodeURIComponent(token);
        setDecodedToken(decoded);
    }, [token]);

    useEffect(() => {
        if (resetSuccess) {
            navigate('/home');
        }
    }, [resetSuccess, navigate]);

    const isStrongPassword = (password) => {
        const passwordRegex = /^(?=.*[A-Z])(?=.*\d).{6,}$/;
        return passwordRegex.test(password);
    };

    const handleSubmit = async () => {
        if (password !== confirmPassword) {
            setError('Passwords do not match.');
            return;
        }

        if (!isStrongPassword(password)) {
            setError('Password must have at least 6 characters, contain at least one uppercase, and one digit.');
            return;
        }

        try {
            setProcessing(true);
            await resetPassword({ "Email": email, "Token": decodedToken, "NewPassword": password });
            setResetSuccess(true);
        } catch (error) {
            console.error('An error occurred while resetting your password.');
            setEmailError('Failed to reset your password. Please ensure you are using the correct email address.');
        } finally {
            setProcessing(false);
        }
    };

    return (
        <Container maxWidth="xs" sx={LoginContainerStyles.container}>
            <Paper elevation={0} style={{ padding: 16, display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
                <Typography variant="h5" gutterBottom sx={LoginContainerStyles.typography}>
                    Reset Password
                </Typography>
                <TextField
                    label={
                        <Typography variant="body1" style={{ fontFamily: 'Segoe UI' }}>
                            Email
                        </Typography>
                    }
                    type="email"
                    fullWidth
                    margin="normal"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    error={emailError !== ''}
                    helperText={emailError}
                    variant="standard"
                    sx={LoginContainerStyles.input}
                />
                <TextField
                    label={
                        <Typography variant="body1" style={{ fontFamily: 'Segoe UI' }}>
                            New Password
                        </Typography>
                    }
                    type="password"
                    fullWidth
                    margin="normal"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    error={error !== '' && error !== 'Passwords do not match.'}
                    helperText={error !== 'Passwords do not match.' && error}
                    variant="standard"
                    sx={LoginContainerStyles.input}
                />
                <TextField
                    label={
                        <Typography variant="body1" style={{ fontFamily: 'Segoe UI' }}>
                            Confirm Password
                        </Typography>
                    }
                    type="password"
                    fullWidth
                    margin="normal"
                    value={confirmPassword}
                    onChange={(e) => setConfirmPassword(e.target.value)}
                    error={error === 'Passwords do not match.'}
                    helperText={error === 'Passwords do not match.' && error}
                    variant="standard"
                    sx={LoginContainerStyles.input}
                />
                {processing && <CircularProgress style={{ margin: '16px 0' }} />}
                <Button variant="contained" color="primary" fullWidth onClick={handleSubmit} sx={LoginContainerStyles.button}>
                    Submit
                </Button>
            </Paper>
        </Container>
    );
};

export default ResetPasswordPage;
