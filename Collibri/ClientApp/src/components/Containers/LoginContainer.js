import React, {useState} from 'react';
import {TextField, Button, Typography, Container, Paper, Box, CircularProgress} from '@mui/material';
import { LoginContainerStyles } from '../../styles/LoginContainerStyles.js';
import ForgotPasswordModal from "../Modals/ForgotPasswordModal";
import CreateAccountModal from "../Modals/CreateAccountModal";
import {loginUser} from "../../api/LoginAPI";
import modalStyles from "../../styles/ForgotPasswordModalStyles";
import {useNavigate} from "react-router-dom";

const LoginContainer = ({ onLoginStatusChange }) => {
    const [forgotPasswordModalOpen, setForgotPasswordModalOpen] = useState(false);
    const [isRegistrationModalOpen , setRegistrationModalOpen] = useState(false);
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [processing, setProcessing] = useState(false);
    const [fieldVisibility, setFieldVisibility] = useState(true);
    const [wrongData, setWrongData] = useState(false);
    const [emptyUsername, setEmptyUsername] = useState(false);
    const [emptyPassword, setEmptyPassword] = useState(false);
    const [errorMessage, setErrorMessage] = useState('');
    const navigate = useNavigate();

    const handleForgotPasswordClick = () => {
        setForgotPasswordModalOpen(true);
    };
    
    const closeForgotPasswordModal = () => {
        setForgotPasswordModalOpen(false);
    };

    const handleRegistrationClick = () => {
        setRegistrationModalOpen(true);
    }
    const closeRegistrationModal = () => {
        setRegistrationModalOpen(false);
    }
    
    const handleSubmit = async () => {
        if(username === '') {
            setErrorMessage('Fields cannot be empty');
            setEmptyUsername(true);
            setWrongData(true);
        }
        if(password === '') {
            setErrorMessage('Fields cannot be empty');
            setEmptyPassword(true);
            setWrongData(true);
        }
        if(username !== '' && password !== '') {
            setFieldVisibility(false);
            setProcessing(true);
            setWrongData(false);
            setEmptyUsername(false);
            setEmptyPassword(false);

            const response = await loginUser({ "Username": username, "Password": password });

            if(typeof response === 'object' && response.Username === username) {
                navigate('/home');
                setProcessing(false);
                setFieldVisibility(true);
                onLoginStatusChange(true);
            } else if(typeof response === 'number' && response === 404) {
                setErrorMessage('Incorrect username or password. Please try again');
                setProcessing(false);
                setFieldVisibility(true);
                setWrongData(true);
            }   
        }
    }
    
    return (
        <Box sx={LoginContainerStyles.container}>
            {/*<Box>*/}
            {/*    <Box sx={{ fontSize: '3rem', position:'absolute', backdropFilter: 'blur(4px)'}}>a</Box>*/}
            {/*    <Box sx={{ fontSize: '3rem'}}>O</Box>*/}
            {/*</Box>*/}
            {processing && (
                <Box sx={LoginContainerStyles.loadingContainer}>
                    <Typography>Logging in...</Typography>
                    <CircularProgress sx={modalStyles.progressIndicator} color="inherit" />
                </Box>
            )}
            <Container maxWidth="xs" style={LoginContainerStyles.formContainer}>
                <Typography variant="h5" gutterBottom style={LoginContainerStyles.typography}>
                    Login
                </Typography>
                <Typography variant="body2" style={LoginContainerStyles.link} >
                    Need an account?            
                    <span style={{ cursor: 'pointer', color:"#1D1E18" }} onClick={handleRegistrationClick}>
                        &nbsp;Register
                    </span>
                </Typography>
                <Box sx={{ mt: 1 }}>
                    <Box sx={LoginContainerStyles.fieldContainer}>
                        {fieldVisibility && <TextField
                            error={emptyUsername}
                            margin="normal"
                            required
                            fullWidth
                            id="username"
                            label="Username"
                            name="username"
                            value={username}
                            onChange={(e) => {
                                setEmptyUsername(false);
                                setUsername(e.target.value);
                            }}
                            autoComplete="username"
                            sx={LoginContainerStyles.input}
                        />}
                        {fieldVisibility && <TextField
                            error={emptyPassword}
                            margin="normal"
                            required
                            fullWidth
                            name="password"
                            label="Password"
                            type="password"
                            id="password"
                            value={password}
                            onChange={(e) => {
                                setEmptyPassword(false);
                                setPassword(e.target.value);
                            }}
                            autoComplete="current-password"
                            sx={LoginContainerStyles.input}
                        />}
                        {wrongData && <Typography sx={LoginContainerStyles.wrongData}>
                            {errorMessage}
                        </Typography>}
                    </Box>
                    <Typography variant="body2" style={LoginContainerStyles.link}>
                        <span style={{ cursor: 'pointer' }} onClick={handleForgotPasswordClick}>
                            Forgot Password?
                        </span>
                    </Typography>
                    {fieldVisibility && <Button fullWidth variant="contained" style={LoginContainerStyles.button} onClick={() => {
                        handleSubmit();
                    }}>
                        Login
                    </Button>}
                </Box>
            </Container>
            <ForgotPasswordModal
                open={forgotPasswordModalOpen}
                onClose={closeForgotPasswordModal}
            />
            <CreateAccountModal
            open={isRegistrationModalOpen}
            onClose={closeRegistrationModal}
            />
        </Box>
    );
};

export default LoginContainer;


