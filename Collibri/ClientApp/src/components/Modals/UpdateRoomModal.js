import React, {useRef, useState} from "react";

import {TextField, Typography} from "@mui/material";
import CModal from "./CModal";
import {modalTextField, modalTitleStyle} from "../../styles/UpdatePostModalStyle";
import {CModalStyle} from "../../styles/CModalStyle";


const UpdateRoomModal = (props) => {
    const nameFieldRef = useRef(null);
    const [error, setError] = useState(false);

    const handleClose = () => {
        props.setUpdateModal(false);
        setError(false);
    }

    const handleOnChange = () => {
        if(nameFieldRef.current.value.trim() !== '' && nameFieldRef.current.value !== props.room.name) {
            setError(false);
        } else {
            setError(true);
        }
    }

    const handleChanges = () => {
        if(!error && nameFieldRef.current.value !== '') {
            props.updateRoomName(nameFieldRef.current.value.trim());
            handleClose();
        } else {
            setError(true);
        }
    }

    return (
        <>
            <CModal showModal={props.updateModal} handleClose={handleClose} handleChanges={handleChanges} >
                <Typography id='modal-modal-title' variant='h5' component='h5' sx={[CModalStyle.text, modalTitleStyle]}>
                    Update name of '{props.room.name}'
                </Typography>
                <TextField
                    error={error}
                    inputRef={nameFieldRef}
                    size='small'
                    label='Name'
                    helperText={error ? 'Name must differ from previous one/not be empty.' : ' '}
                    onChange={handleOnChange}
                    sx={modalTextField}
                />
            </CModal>
        </>
    );
}

export default UpdateRoomModal