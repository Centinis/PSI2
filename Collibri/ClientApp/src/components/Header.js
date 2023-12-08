import React from 'react';
import { AppBar, Toolbar, Box, IconButton, Typography, Tooltip } from '@mui/material';
import ArrowBackIcon from '@mui/icons-material/ArrowBack';
import { HeaderStyles } from '../styles/HeaderStyles';
import { useNavigate } from 'react-router-dom';

const Header = ({ roomSettings }) => {
    const navigate = useNavigate();

    return (
        <AppBar position="static" style={HeaderStyles.appBar}>
            <Toolbar style={HeaderStyles.toolbar}>
                <Box style={HeaderStyles.box}>
                    <Tooltip title="Go back to room selection">
                        <IconButton color="inherit" aria-label="Back" onClick={() => navigate('/home')}>
                            <ArrowBackIcon style={HeaderStyles.backButton} />
                        </IconButton>
                    </Tooltip>
                    <Tooltip title="View room settings">
                        {roomSettings}
                    </Tooltip>
                </Box>
                <img src="/logo.png" alt="Logo" style={{ height: '7vh', width: '7vh', marginLeft: 'auto' }} />
            </Toolbar>
        </AppBar>
    );
};

export default Header;
