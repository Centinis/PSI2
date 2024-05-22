import React, {useRef, useState} from "react";
import {TextField, Typography} from "@mui/material";
import CModal from "./CModal";
import {modalTextField, modalTitleStyle} from "../../styles/UpdatePostModalStyle";
import {CModalStyle} from "../../styles/CModalStyle";



const UpdateSectionModal = (props) => {
    const nameFieldRef = useRef(null);
    const [isEmptyError, setIsEmptyError] = useState(false);
    const [isAlreadyUsedError, setIsAlreadyUsedError] = useState(false);

    const handleClose = () => {
        props.setUpdateModal(false);
        setIsEmptyError(false);
        setIsAlreadyUsedError(false);
    }

    const handleOnChange = () => {
        setIsEmptyError(false);
        setIsAlreadyUsedError(false);
    }

    function handleUpdateSection() {

        if (nameFieldRef.current.value.trim() === '') {
            setIsEmptyError(true);
            return;
        } else if (props.sections.some(section => section.sectionName === nameFieldRef.current.value.trim())) {
            setIsAlreadyUsedError(true);
            return;
        } else {
            handleClose();
            props.updateSection(nameFieldRef.current.value.trim());
        }
    }

    return (
        <>
            <CModal showModal={props.updateModal} handleClose={handleClose} handleChanges={handleUpdateSection}>
                <Typography id='modal-modal-title' variant='h5' component='h5' sx={[CModalStyle.text, modalTitleStyle]}>
                    Update name of '{props.section.sectionName}'
                </Typography>
                <TextField
                    error={isEmptyError || isAlreadyUsedError}
                    inputRef={nameFieldRef}
                    size='small'
                    label='Name'
                    helperText={
                        isEmptyError
                            ? 'Section name cannot be empty'
                            : isAlreadyUsedError
                                ? 'Section name is already used'
                                : ' '
                    }
                    onChange={handleOnChange}
                    sx={modalTextField}
                />
            </CModal>
        </>
    );

}
export default UpdateSectionModal