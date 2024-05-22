import React, {useState, useEffect} from 'react';
import {
    Grid,
    ThemeProvider,
    Typography,
    Button,
    Box,
    IconButton,
    Switch,
    FormControlLabel,
    Fade,
    Tooltip, styled
} from '@mui/material';
import InfoIcon from '@mui/icons-material/Info';
import ExitToAppIcon from '@mui/icons-material/ExitToApp';
import {headerStyle, headerTextTheme} from '../../styles/LandingPageStyle';
import {CreateRoom} from '../Buttons/CreateRoom';
import LogoutIcon from '@mui/icons-material/Logout';
import {JoinRoom} from '../Buttons/JoinRoom';
import {RoomContainer} from '../Containers/RoomContainer';
import {AboutUsButton} from '../Buttons/AboutUsButton';
import LoginContainer from '../Containers/LoginContainer';
import ResetPasswordContainer from '../Containers/ResetPasswordContainer';
import {onLogin, onLogout} from "../../state/user/userSlice";
import {useDispatch, useSelector} from "react-redux";
import {useLocation} from "react-router-dom";
import {LoginContainerStyles} from "../../styles/LoginContainerStyles";
import {useNavigate} from "react-router-dom";

export const LandingPageLayout = () => {
    const userInformation = useSelector((state) => state.user);
    const [rooms, setRooms] = useState([]);
    const dispatch = useDispatch();
    const location = useLocation();
    const navigate = useNavigate();
    const [isGreen, setIsGreen] = useState(false);

    useEffect(() => {
        // Check for stored login status on page load
        const storedLoginStatus = localStorage.getItem('loggedIn');
        
        if (storedLoginStatus) {
            dispatch(onLogin(JSON.parse(storedLoginStatus).username));
        }
    }, []);

    const TextOnlyTooltip = styled(({className, ...props}) => (
        <Tooltip {...props} componentsProps={{tooltip: {className: className}}}/>
    ))(`
    color: black;
    background-color: transparent;
`);
    const handleColor = () => {
        // Change color to green when logging in
        setIsGreen(true);

        // Reset the color back to white after a brief delay (e.g., 1 second)

        setTimeout(() => {
            setIsGreen(false);
        }, 500);


    };


    // Callback function to update login status
    const handleLoginStatus = (status, response) => {
        // Store the login status in localStorage
        localStorage.setItem('loggedIn', JSON.stringify({username: response, loggedIn: status}));
    };

    // Function to handle logout
    const handleLogout = () => {
        // Clear login status from localStorage
        localStorage.removeItem('loggedIn');

        // Update the loggedIn state
        
            dispatch(onLogout());
        
    };

    const isResetPasswordPage = location.pathname.startsWith('/reset-password/');

    return (
        <Grid container style={{ width: '100vw', height: '100vh' }}>
            {/* Header */}
            <Grid item xs={6} style={{
                ...headerStyle,
                backgroundImage: `url("${userInformation.loggedIn ? '/background5_recolored.svg' : '/background5.svg'}")`,
                backgroundSize: 'cover',
                backgroundPosition: 'center',
                transition: 'background-image 0.5s ease-in-out',
            }}>
                <ThemeProvider theme={headerTextTheme}>
                    <Typography style={{
                        color: isGreen ? '#6ada91' : 'white',
                        transition: 'color 0.5s ease-in-out', // Optional: Add a transition effect
                    }}
                    >Collibri
                    </Typography>
                </ThemeProvider>
            </Grid>

            {/* Main Content */}
            <Grid item xs={6} container direction="column" justifyContent="center" alignItems="center"
                  style={{minHeight: '100vh', backgroundColor: '#DEFEF5'}}>
                <Box>
                    <img src="/logo.png" alt="Collibri Logo" style={{ height: '15vh', width: 'auto', marginBottom: '50vh' }} />
                </Box>
                <Box sx={{marginTop: '-45vh', marginBottom: '3vh', minHeight: '50vh'}}>
                    {userInformation.loggedIn ? (
                        <Fade in={true} {...({timeout: 1500})}>
                            <Box>
                                <Box style={{
                                    position: 'absolute',
                                    top: '5%',
                                    right: '5%',
                                    transform: 'translateX(50%)'
                                }}>
                                    <TextOnlyTooltip placement="bottom" title="Sign Out"
                                                     sx={{fontSize: '1.1rem', backgroundColor: 'white'}}>
                                        <IconButton color="success" onClick={handleLogout}>
                                            <LogoutIcon fontSize="large"/>
                                        </IconButton>
                                    </TextOnlyTooltip>
                                </Box>
                                <Box style={{
                                    position: 'absolute',
                                    bottom: '5%',
                                    right: '5%',
                                    transform: 'translateX(50%)'
                                }}>
                                    <TextOnlyTooltip placement="left-start" title="More About Us"
                                                     sx={{fontSize: '1.1rem', backgroundColor: 'white'}}>
                                        <IconButton>
                                            <InfoIcon onClick={() => navigate("/about")} fontSize="large"
                                                      color="success"/>
                                        </IconButton>
                                    </TextOnlyTooltip>
                                </Box>
                                <Box display="flex" flexDirection="column" justifyContent="center" alignItems="center">
                                    <Typography variant="h5" gutterBottom
                                                style={{...LoginContainerStyles.typography, paddingTop: '1.2rem'}}>
                                        Your rooms
                                    </Typography>
                                    <RoomContainer rooms={rooms} setRooms={setRooms}/>
                                    <Box display="flex" justifyContent="space-between" width="25rem" mt={5}>
                                        <CreateRoom/>
                                        <JoinRoom/>
                                    </Box>
                                </Box>
                            </Box>
                        </Fade>
                    ) : (
                        isResetPasswordPage ? (
                            <ResetPasswordContainer />
                        ) : (
                            <Box display="flex" flexDirection="column" justifyContent="center" alignItems="center">
                                <LoginContainer onLoginStatusChange={handleLoginStatus} handleColor={handleColor}/>
                            </Box>
                )
                )}
            </Box>
        </Grid>
</Grid>
);
};
