import React, { useRef, useState } from "react";
import {Box, Button, Modal, TextField, Typography} from "@mui/material";
import { Check, Clear } from "@mui/icons-material";
import { createNote } from "../../api/NoteAPI"; 
import { CreateNoteStyle } from "../../styles/CreateNoteStyle";
import {CModalStyle} from "../../styles/CModalStyle";

export const CreateNoteModal = (props) => {
    const titleFieldRef = useRef(null);
    const descFieldRef = useRef(null);
    const [isTitleEmptyError, setIsTitleEmptyError] = useState(false);
    const [isDescEmptyError, setIsDescEmptyError] = useState(false);
    const [isTitleTooLongError, setIsTitleTooLongError] = useState(false);
    const [isDescTooLongError, setIsDescTooLongError] = useState(false);
    const [errorMessage, setErrorMessage] = useState(null);

    const handleOnChangeTitle = () => {
        setIsTitleEmptyError(false);

        if (titleFieldRef.current.value.trim().length > 20) {
            setIsTitleTooLongError(true);
        } else {
            setIsTitleTooLongError(false);
        }
    };

    const handleOnChangeDesc = () => {
        setIsDescEmptyError(false);

        if (descFieldRef.current.value.trim().length > 80) {
            setIsDescTooLongError(true);
        } else {
            setIsDescTooLongError(false);
        }
    };

    function handleCreateNote() {
        const title = titleFieldRef.current.value.trim();
        const desc = descFieldRef.current.value.trim();

        const noteData = {
            Name: title,
            Text: desc,
            PostId: props.postId,
        };

        createNote(JSON.stringify(noteData))
            .then(() => {
                props.handleSuccessfulClose();
            })
            .catch((error) => {
                if (error.message === 'Note already exists') {
                    setErrorMessage("Note already exists. Please choose a different title.");
                } else {
                    setErrorMessage("Error saving note. Please try again.");
                }
            });
    }


    const handleClose = () => {
        setIsTitleEmptyError(false);
        setIsTitleTooLongError(false);
        setIsDescEmptyError(false);
        setIsDescTooLongError(false);
        setErrorMessage(null);
        
        props.setOpen(false);
    };

    return (
        <Modal open={props.showModal} onClose={() => handleClose()}>
            <Box sx={CreateNoteStyle.modalWindow} align="center">
                <Typography variant='h4' sx={[CModalStyle.text, {marginBottom: '5%'}]}>
                    Create a note
                </Typography>
                <Box sx={CreateNoteStyle.textFieldBox}>
                    <TextField
                        label="Note title"
                        variant="standard"
                        multiline
                        error={isTitleEmptyError || isTitleTooLongError}
                        inputRef={titleFieldRef}
                        onChange={handleOnChangeTitle}
                        helperText={
                            isTitleEmptyError
                                ? "Title cannot be empty"
                                : isTitleTooLongError
                                    ? "Title cannot be longer than 20 characters"
                                    : "Max 20 characters"
                        }
                        sx={CreateNoteStyle.nameTextField}
                    />
                </Box>
                <Box sx={CreateNoteStyle.textFieldBox}>
                    <TextField
                        id="outlined-basic"
                        label="Note description"
                        variant="outlined"
                        error={isDescEmptyError || isDescTooLongError}
                        inputRef={descFieldRef}
                        onChange={handleOnChangeDesc}
                        multiline
                        rows={3}
                        helperText={
                            isDescEmptyError
                                ? "Description cannot be empty"
                                : isDescTooLongError
                                    ? "Description cannot be longer than 80 characters"
                                    : "Max 80 characters"
                        }
                        sx={CreateNoteStyle.descriptionTextField}
                    />
                </Box>
                <Box sx={CreateNoteStyle.buttonBox}>
                    <Button onClick={handleClose} sx={CModalStyle.buttons}>
                        <Clear />
                    </Button>
                    <Button onClick={handleCreateNote} sx={CModalStyle.buttons}>
                        <Check />
                    </Button>
                </Box>
                {errorMessage && (
                    <Typography color="error" variant="body2">
                        {errorMessage}
                    </Typography>
                )}
            </Box>
        </Modal>
    );
};
