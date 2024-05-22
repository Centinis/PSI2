import React, {useState} from 'react';
import AddFileModal from "../Modals/AddFileModal";
import FileUploadIcon from '@mui/icons-material/FileUpload';
import {IconButton, Tooltip} from "@mui/material";

const AddFileButton = (props) => {
    const [open, setOpen] = useState(false);
    const handleOpen = () => {
        setOpen(true);
    }
    
    return(
        <>
            <Tooltip arrow placement="right" title="Add file">
                <IconButton sx={props.buttonStyle} onClick={handleOpen} disableRipple>
                    <FileUploadIcon fontSize="large"/>
                </IconButton>
                <AddFileModal open={open} setOpen={setOpen} setFiles={props.setFiles} postId={props.postId}/>
            </Tooltip>
        </>
    );
}

export default AddFileButton