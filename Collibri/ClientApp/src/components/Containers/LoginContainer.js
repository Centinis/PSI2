import React, {useState} from 'react';
import {TextField, Button, Typography, Container, Paper, Box, CircularProgress, Grow} from '@mui/material';
import { LoginContainerStyles } from '../../styles/LoginContainerStyles.js';
import ForgotPasswordModal from "../Modals/ForgotPasswordModal";
import CreateAccountModal from "../Modals/CreateAccountModal";
import {loginUser} from "../../api/LoginAPI";
import modalStyles from "../../styles/ForgotPasswordModalStyles";
import {useNavigate} from "react-router-dom";
import {useDispatch} from "react-redux";
import {onLogin} from "../../state/user/userSlice";

const LoginContainer = ({ onLoginStatusChange, handleColor }) => {
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
    const dispatch = useDispatch();

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
            
            if(typeof response === 'string' && response === username) {
                dispatch(onLogin(response));
                setProcessing(false);
                setFieldVisibility(true);
                onLoginStatusChange(true, response);
            } else if(typeof response === 'number' && response === 404) {
                setErrorMessage('Incorrect username or password. Please try again');
                setProcessing(false);
                setFieldVisibility(true);
                setWrongData(true);
            }   
        }
    }
    
    return (
        <Grow in={true} {...({timeout: 1500})}>
            
        <Box sx={LoginContainerStyles.container}>
            
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
                <Box sx={{ mt: 1 }}>
                    <Box sx={LoginContainerStyles.fieldContainer}>
                        {fieldVisibility && <TextField
                            error={emptyUsername}
                            margin="normal"
                            fullWidth
                            id="username"
                            label={
                                <Typography variant="body1" style={{ fontFamily: 'Segoe UI' }}>
                                    Username
                                </Typography>
                            }
                            name="username"
                            variant="standard"
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
                            fullWidth
                            name="password"
                            label={
                                <Typography variant="body1" style={{ fontFamily: 'Segoe UI' }}>
                                    Password
                                </Typography>
                            }
                            type="password"
                            id="password"
                            variant="standard"
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
                    <Typography variant="body2" style={{ ...LoginContainerStyles.link, textAlign: 'right' , marginTop: '-2vh'}}>
                        <span style={{ cursor: 'pointer' }} onClick={handleForgotPasswordClick}>
                            Forgot Password?
                        </span>
                    </Typography>
                    {fieldVisibility && <Button variant="contained" style={LoginContainerStyles.button} onClick={() => {
                        handleSubmit();
                        handleColor();
                    }}>
                        Log in
                    </Button>}
                    <Typography variant="body2" style={{...LoginContainerStyles.link, marginTop: '5vh'}} >
                        Need an account?
                        <span style={{ cursor: 'pointer', color:"#1D1E18" }} onClick={handleRegistrationClick}>
                        &nbsp;Sign up
                    </span>
                    </Typography>
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
        </Grow>
    );
};

export default LoginContainer;


