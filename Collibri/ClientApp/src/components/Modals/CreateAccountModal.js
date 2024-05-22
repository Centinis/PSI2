import {Grid, Box, Button, CircularProgress, IconButton, Modal, TextField, Tooltip, Typography} from "@mui/material";
import React, {useState} from "react";
import modalStyles from "../../styles/ForgotPasswordModalStyles";
import {Check, Close, Replay} from "@mui/icons-material";
import {registerUser} from "../../api/RegisterAPI";

const CreateAccountModal = ({open, onClose}) => {

    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [passwordValidation, setPasswordValidation] = useState('');
    const [email, setEmail] = useState('');
    const [incorrectEmail, setIncorrectEmail] = useState(false);
    const [incorrectUsername, setIncorrectUsername] = useState(false);
    const [incorrectPassword, setIncorrectPassword] = useState(false);
    const [processing, setProcessing] = useState(false);
    const [passwordMatch, setPasswordMatch] = useState(false);
    const [success, setSuccess] = useState('waiting');
    const emailRegex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
    const passwordRegex = /^(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,}$/;
    
    const handleSubmit = (e) => {
        if(!emailRegex.test(email)) {
            setIncorrectEmail(true);
        }
        if(username.trim() === '') {
            setIncorrectUsername(true);
        }
        if(!passwordRegex.test(password)) {
            setIncorrectPassword(true);
        }
        if(password !== passwordValidation) {
            setPasswordMatch(true);
        }
        
        if(emailRegex.test(email) && !(username.trim() === '') && passwordRegex.test(password) && password === passwordValidation) {
            setProcessing(true);
            
            const response = 
                registerUser({ "Username": username, "Email": email, "Password": password })
                    .then(data => {
                        if(data.Username === username && data.Email === email) {
                            setSuccess('pass');
                        } else {
                            setSuccess('fail');
                        }
                    })
                    .catch(err => {
                        console.log(err);
                        setSuccess('fail')
                    })
        }
    };
    
    const setAllToInitial = () => {
        setIncorrectUsername(false);
        setIncorrectPassword(false);
        setIncorrectEmail(false);
        setPasswordMatch(false);

        setUsername('');
        setPassword('');
        setEmail('');
        setPasswordValidation('');
        
        setSuccess('waiting');
        setProcessing(false);
    }
    
    const handleClose = () => {
        setAllToInitial()
        onClose();
    }
    
    return (
        <Modal open={open} onClose={() =>  handleClose()} centered>
            <Box sx={modalStyles.registerContainer}>
                { processing ? (
                    success === 'pass' ? (
                      <Box sx={modalStyles.processing}>
                          <Typography sx={{ fontFamily: 'Segoe UI' }}>
                              Account created successfully
                          </Typography>
                          <IconButton sx={modalStyles.progressIndicator} onClick={() => {
                              handleClose()
                          }}>
                              <Check />
                          </IconButton>
                      </Box>
                    ) : success === 'fail' ? (
                      <Box sx={modalStyles.processing}>
                          <Typography sx={{ fontFamily: 'Segoe UI' }}>Oops! Something went wrong...</Typography>
                          <Typography sx={{ fontFamily: 'Segoe UI' }}>Please try again!</Typography>
                          <Box sx={modalStyles.closeRepeatContainer}>
                              <IconButton onClick={() => {
                                  handleClose();
                              }}>
                                  <Close />
                              </IconButton>
                              <IconButton onClick={() => {
                                  setAllToInitial();
                              }}>
                                  <Replay />
                              </IconButton>
                          </Box>
                      </Box>
                    ) : (
                      <Box sx={modalStyles.processing}>
                          <Typography>Processing...</Typography>
                          <CircularProgress sx={modalStyles.progressIndicator} color="inherit" />
                      </Box>
                    )   
                ) : (
                  <Box>
                      <Box sx={modalStyles.topContainer}>
                          <Typography sx={modalStyles.title} variant="h6" gutterBottom>
                              Create an account
                          </Typography>
                          <IconButton onClick={() => {
                              handleClose()
                          }}>
                              <Close />
                          </IconButton>
                      </Box>
                      <Grid container spacing={2}>
                          {/* Left column */}
                          <Grid item xs={12} sm={6}>
                              <TextField
                                  fullWidth
                                  error={incorrectUsername}
                                  margin="normal"
                                  onEmptied="Field cannot be empty!"
                                  label={
                                      <Typography variant="body1" style={{ fontFamily: 'Segoe UI' }}>
                                          Username
                                      </Typography>
                                  }
                                  variant="standard"
                                  value={username}
                                  onChange={(e) => {
                                      setIncorrectUsername(false);
                                      setUsername(e.target.value);
                                  }}
                                  sx={modalStyles.inputField}
                              />
                              <Box sx={modalStyles.helperTextBox}>
                                  {incorrectUsername && (
                                      <Typography sx={modalStyles.errorHelperText}>
                                          Username field cannot be empty!
                                      </Typography>
                                  )}
                              </Box>
                              <TextField
                                  fullWidth
                                  error={incorrectEmail}
                                  margin="normal"
                                  label={
                                      <Typography variant="body1" style={{ fontFamily: 'Segoe UI' }}>
                                          Email
                                      </Typography>
                                  }
                                  variant="standard"
                                  value={email}
                                  onChange={(e) => {
                                      setIncorrectEmail(false);
                                      setEmail(e.target.value);
                                  }}
                                  sx={{...modalStyles.inputField, marginTop: '2.01rem'}}
                              />
                              <Box sx={modalStyles.helperTextBox}>
                                  {incorrectEmail && (
                                      <Typography sx={modalStyles.errorHelperText}>
                                          Incorrect format (ex: something@smth.com)
                                      </Typography>
                                  )}
                              </Box>
                          </Grid>
                          {/* Right column */}
                          <Grid item xs={12} sm={6}>
                              <TextField
                                  fullWidth
                                  error={incorrectPassword}
                                  margin="normal"
                                  label={
                                      <Typography variant="body1" style={{ fontFamily: 'Segoe UI' }}>
                                          Password
                                      </Typography>
                                  }
                                  variant="standard"
                                  value={password}
                                  type="password"
                                  onChange={(e) => {
                                      setIncorrectPassword(false);
                                      setPassword(e.target.value);
                                  }}
                                  sx={modalStyles.inputField}
                              />
                              <Box sx={modalStyles.helperTextBox}>
                                  {incorrectPassword ? (
                                      <Typography sx={modalStyles.errorHelperText}>
                                          Password must have at least 6 characters, contain at least one uppercase and one digit
                                      </Typography>
                                  ) : (
                                      <Typography sx={modalStyles.helperText}>
                                          Password must have at least 6 characters, contain at least one uppercase and one digit
                                      </Typography>
                                  )}
                              </Box>
                              <TextField
                                  fullWidth
                                  error={passwordMatch}
                                  margin="normal"
                                  label={
                                      <Typography variant="body1" style={{ fontFamily: 'Segoe UI' }}>
                                          Confirm password
                                      </Typography>
                                  }
                                  variant="standard"
                                  value={passwordValidation}
                                  type="password"
                                  onChange={(e) => {
                                      setPasswordMatch(false);
                                      setPasswordValidation(e.target.value);
                                  }}
                                  sx={modalStyles.inputField}
                              />
                              <Box sx={modalStyles.helperTextBox}>
                                  {passwordMatch && (
                                      <Typography sx={modalStyles.errorHelperText}>
                                          Passwords must match!
                                      </Typography>
                                  )}
                              </Box>
                          </Grid>
                      </Grid>
                      <Button
                          variant="contained"
                          sx={{
                              ...modalStyles.button,
                              '&:hover': {
                                  backgroundColor: modalStyles.button.backgroundColor,
                              },
                          }} onClick={() => handleSubmit()}
                      >
                          Register
                      </Button>
                  </Box>
                )}
            </Box>
        </Modal>
    );
};
export default CreateAccountModal;