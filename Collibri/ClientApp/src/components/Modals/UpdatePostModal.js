import React, { useState, useRef } from 'react';
import { TextField, Typography } from '@mui/material';
import CModal from "./CModal";
import {modalTextField, modalTitleStyle} from "../../styles/UpdatePostModalStyle";
import {CModalStyle} from "../../styles/CModalStyle";



const UpdatePostModal = (props) => {
  const titleFieldRef = useRef(null);
  const [error, setError] = useState(false);

  const handleClose = () => {
    props.setUpdateModal(false);
    setError(false);
  }
  
  const handleOnChange = () => {
    if(titleFieldRef.current.value.trim() !== '' && titleFieldRef.current.value !== props.title) {
      setError(false);
    } else {
      setError(true);
    }
  }
  
  const handleChanges = () => {
    if(!error && titleFieldRef.current.value !== '') {
      props.updatePostContent('title', titleFieldRef.current.value.trim());
      handleClose();
    } else {
      setError(true);
    }
  }
  
  return (
    <>
      <CModal showModal={props.updateModal} handleClose={handleClose} handleChanges={handleChanges} >
        <Typography id='modal-modal-title' variant='h5' component='h5' sx={[CModalStyle.text, modalTitleStyle]}>
          Update title of '{props.title}'
        </Typography>
        <TextField
          error={error}
          inputRef={titleFieldRef}
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

export default UpdatePostModal
