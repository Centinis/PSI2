import React, {useState} from 'react';
import {Box, CircularProgress, Grid, IconButton, Modal, TextField, Typography} from "@mui/material";
import CheckIcon from '@mui/icons-material/Check';
import FileUploadIcon from '@mui/icons-material/FileUpload';
import {uploadFile} from "../../api/FileAPI";
import {AddFileStyle} from "../../styles/AddFileStyle";
import imageCompression from 'browser-image-compression';
import {CModalStyle} from "../../styles/CModalStyle";

const AddFileModal = (props) => {
    const [file, setFile] = useState(null);
    const [error, setError] = useState(true);
    const [sizeError, setSizeError] = useState(false);
    const [progress, setProgress] = useState(0);
    
    const handleUpload = () => {
        const formData = new FormData();
        formData.append('file', file, file.name);
        uploadFile(props.postId, formData, props.setFiles);

        handleClose();
    }
    
    const handleClose = () => {
        props.setOpen(false);
        setError(true);
        setSizeError(false);
        setFile(null);
        setProgress(0);
    }
    
    const handleOnChange = async (event) => {
        const uploadedFile = event.target.files[0];
        
        if (uploadedFile === null || uploadedFile === undefined) {
            setError(true);
            return;
        } else if (uploadedFile.size > 5e6) {
            setSizeError(true);
            return;
        } else {
            setError(false);
            setSizeError(false);
        }
        
        if (uploadedFile.name.match(/\.(jpg|jpeg|png)$/i)) {
            console.log(`Image size before compression: ${uploadedFile.size / 1024} KB`)
            //Compress image
            const options = {
                maxSizeMB: 2,
                maxWidthOrHeight: 1080,
                useWebWorker: true,
                onProgress: setCurrentProgress
            }
            
            try {
                const compressedFile = await imageCompression(uploadedFile, options);
                console.log(`${compressedFile.name} compressedFile size ${compressedFile.size / 1024} KB`);
                setFile(compressedFile);
            } catch (error) {
                console.log(error);
            }
        } else {
            setFile(uploadedFile);
            setProgress(100);
        }
    }
    
    const setCurrentProgress = (progressValue) => {
        setProgress(progressValue);
    }
    
    return(
        <Modal open={props.open} onClose={handleClose}>
            <Box sx={AddFileStyle.modal}>
                <Typography sx={[AddFileStyle.headerText, CModalStyle.text]}>
                    Select a file to add to this post:
                </Typography>
                <Grid sx={AddFileStyle.uploadBox}>
                    <TextField error={sizeError}
                               helperText={sizeError === true ? "Files must be under 5 MB" : (error === true ? "File not selected" : "")}
                               type="file" onChange={handleOnChange} sx={{borderRadius: 3, color: '#B9F5D9'}}
                    />
                    <IconButton disabled={error || sizeError || progress !== 100} onClick={handleUpload} sx={CModalStyle.buttons}>
                        <FileUploadIcon fontSize="large" />
                    </IconButton>
                </Grid>
                <Box sx={AddFileStyle.progressBox}>
                    {progress === 100
                        ? <CheckIcon fontSize="large" color="success" />
                        : <CircularProgress variant="determinate" value={progress} />}
                </Box>
            </Box>
        </Modal>
    );
}

export default AddFileModal