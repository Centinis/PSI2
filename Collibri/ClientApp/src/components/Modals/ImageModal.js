import React from 'react';
import {Typography, Box, Card, CardMedia, Modal} from "@mui/material";
import {ImageModalStyle} from "../../styles/ImageModalStyle";

const ImageModal = (props) => {
    
    const handleClose = () => {
        props.setOpen(false);
    }
    
    return(
        <>
            <Modal open={props.open} onClose={handleClose}>
                <Box sx={ImageModalStyle.modal}>
                    <CardMedia component="img" image={props.imageURL} sx={ImageModalStyle.media} />
                </Box>
            </Modal>
        </>
    );
}

export default ImageModal