import React, {useState} from 'react';
import {TextField, Button, Typography, Container, Paper, Box, CircularProgress} from '@mui/material';
import { Tooltip } from '@mui/material';
import { LoginPageStyles } from '../styles/LoginPageStyles.js';
import ForgotPasswordModal from "./ForgotPasswordModal";
import CreateAccountModal from "./CreateAccountModal";
import {loginUser} from "../api/LoginAPI";
import modalStyles from "../styles/ForgotPasswordModalStyles";
import {useNavigate} from "react-router-dom";

const LoginPage = () => {
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
            } else if(typeof response === 'number' && response === 404) {
                setErrorMessage('Incorrect username or password. Please try again');
                setProcessing(false);
                setFieldVisibility(true);
                setWrongData(true);
            }   
        }
    }
    
    return (
        <Box style={LoginPageStyles.container}>
            <Box style={LoginPageStyles.header}>
                <Typography variant="h4" gutterBottom style={{ ...LoginPageStyles.typography, color: '#000000' }}>
                    Collibri
                </Typography>
            </Box>
            {/*<Box>*/}
            {/*    <Box sx={{ fontSize: '3rem', position:'absolute', backdropFilter: 'blur(4px)'}}>a</Box>*/}
            {/*    <Box sx={{ fontSize: '3rem'}}>O</Box>*/}
            {/*</Box>*/}
            {processing && (
                <Box sx={LoginPageStyles.loadingContainer}>
                    <Typography>Logging in...</Typography>
                    <CircularProgress sx={modalStyles.progressIndicator} color="inherit" />
                </Box>
            )}
            <Container maxWidth="xs" style={LoginPageStyles.formContainer}>
                <Paper elevation={0} style={LoginPageStyles.paper}>
                    <Typography variant="h5" gutterBottom style={LoginPageStyles.typography}>
                        Login
                    </Typography>
                    <Typography variant="body2" style={LoginPageStyles.link} >
                        Need an account?            
                        <span style={{ cursor: 'pointer', color:"black" }} onClick={handleRegistrationClick}>
                                    &nbsp;Register
                                </span>
                    </Typography>
                    <Box sx={{ mt: 1 }}>
                        <Box sx={LoginPageStyles.fieldContainer}>
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
                              sx={LoginPageStyles.input}
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
                              sx={LoginPageStyles.input}
                            />}
                            {wrongData && <Typography sx={LoginPageStyles.wrongData}>
                                {errorMessage}
                            </Typography>}
                        </Box>
                        <Typography variant="body2" style={LoginPageStyles.link}>
                                <span style={{ cursor: 'pointer' }} onClick={handleForgotPasswordClick}>
                                    Forgot Password?
                                </span>
                        </Typography>
                        {fieldVisibility && <Button fullWidth variant="contained" style={LoginPageStyles.button} onClick={() => {
                            handleSubmit();
                        }}>
                            Login
                        </Button>}
                    </Box>
                </Paper>
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

export default LoginPage;


