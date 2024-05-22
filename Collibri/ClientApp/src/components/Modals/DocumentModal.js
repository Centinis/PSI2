import React from "react";
import {Box, IconButton, Modal, Typography} from "@mui/material";
import {DocumentModalStyles} from "../../styles/DocumentModalStyles";
import CloseIcon from '@mui/icons-material/Close';


const DocumentModal = (props) => {
    const handleClose = () => {
        props.setDocumentModal(false);
    }
    
    return(
        <Modal open={props.documentModal} onClose={handleClose}>
            <Box sx={DocumentModalStyles.modal}>
                <Box sx={{display: 'flex', flexDirection: 'row', justifyContent: 'end', marginBottom: '0%'}}>
                    <IconButton onClick={handleClose} sx={DocumentModalStyles.closeButton}>
                        <CloseIcon />
                    </IconButton>
                </Box>
                <Box align='justify' sx={DocumentModalStyles.title}>
                    <Typography variant="h4" sx={{fontFamily: 'Segoe UI semibold', color: '#316C44'}}>
                        {props.title}
                    </Typography>
                </Box>
                <Box sx={DocumentModalStyles.body}>
                    <Typography variant="body1" sx={{fontFamily: 'Segoe UI', color: '#1D1E18'}}>
                        {props.text}
                    </Typography>
                </Box>
            </Box>
        </Modal>
    );
}

export default DocumentModal;