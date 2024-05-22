import {Button} from "@mui/material";
import {JoinCreateRoomStyles} from "../../styles/JoinCreateRoomStyles";
import React from "react";
import {useNavigate} from "react-router-dom";



export const AboutUsButton = () => {

    const navigate = useNavigate();
    
    return (
       
            <Button sx={{
                         ...JoinCreateRoomStyles.button, 
                         color: '#316c44',
                         borderColor: '#80CB9E'}} 
                    size="large" onClick={() => navigate("/about")} variant="outlined">About us</Button>
        
    );
}