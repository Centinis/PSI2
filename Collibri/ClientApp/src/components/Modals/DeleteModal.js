import React from 'react';
import { Typography } from "@mui/material";
import {deleteModalWarningStyle} from "../../styles/DeleteModalStyle";
import CModal from "./CModal";


const DeleteModal = (props) => {
  const handleClose = () => props.setDeleteModal(false);
  const handleChanges = () => {
    props.handleDelete(props.id)
    handleClose();
  };
  
  return(
    <>
      <CModal handleChanges={handleChanges} handleClose={handleClose} showModal={props.deleteModal} >
        <Typography variant="h5">
          Are you sure?
        </Typography>
        <Typography variant="body1" sx={deleteModalWarningStyle}>
          Deleted items cannot be recovered.
        </Typography>
      </CModal>
    </>
  );  
}

export default DeleteModal;