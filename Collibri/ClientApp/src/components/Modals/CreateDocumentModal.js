import React, { useRef, useState } from "react";
import {createDocument} from "../../api/DocumentAPI";
import {Box, Button, Modal, TextField, Typography} from "@mui/material";
import {CModalStyle} from "../../styles/CModalStyle";
import {Check, Clear} from "@mui/icons-material";
import {CreateDocumentStyle} from "../../styles/CreateDocumentStyle";

export const CreateDocumentModal = (props) => {
    const titleFieldRef = useRef(null);
    const descFieldRef = useRef(null);
    const [isTitleEmptyError, setIsTitleEmptyError] = useState(false);
    const [isDescEmptyError, setIsDescEmptyError] = useState(false);
    const [isTitleTooLongError, setIsTitleTooLongError] = useState(false);
    const [isDescTooLongError, setIsDescTooLongError] = useState(false);
    const [errorMessage, setErrorMessage] = useState(null);

    const handleOnChangeTitle = () => {
        setIsTitleEmptyError(false);

        if (titleFieldRef.current.value.trim().length > 30) {
            setIsTitleTooLongError(true);
        } else {
            setIsTitleTooLongError(false);
        }
    };

    const handleOnChangeDesc = () => {
        setIsDescEmptyError(false);

        if (descFieldRef.current.value.trim().length > 5000) {
            setIsDescTooLongError(true);
        } else {
            setIsDescTooLongError(false);
        }
    };

    function handleCreateDocument() {
        const title = titleFieldRef.current.value.trim();
        const desc = descFieldRef.current.value.trim();

        const documentData = {
            Title: title,
            Text: desc,
            PostId: props.postId,
        };

        createDocument(props.postId, JSON.stringify(documentData))
            .then(() => {
                props.handleSuccessfulClose();
            })
            .catch((error) => {
                if (error.message === 'Document already exists') {
                    setErrorMessage("Document already exists. Please choose a different title.");
                } else {
                    setErrorMessage("Error saving document. Please try again.");
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
            <Box sx={CreateDocumentStyle.modalWindow} align="center">
                <Typography variant='h4' sx={[CModalStyle.text, {marginBottom: '5%'}]}>
                    Create a document
                </Typography>
                <Box sx={CreateDocumentStyle.textFieldBox}>
                    <TextField
                        label="Document title"
                        variant="standard"
                        multiline
                        error={isTitleEmptyError || isTitleTooLongError}
                        inputRef={titleFieldRef}
                        onChange={handleOnChangeTitle}
                        helperText={
                            isTitleEmptyError
                                ? "Title cannot be empty"
                                : isTitleTooLongError
                                    ? "Title cannot be longer than 30 characters"
                                    : "Max 30 characters"
                        }
                        sx={CreateDocumentStyle.nameTextField}
                    />
                </Box>
                <Box sx={CreateDocumentStyle.textFieldBox}>
                    <TextField
                        id="outlined-basic"
                        label="Document description"
                        variant="outlined"
                        error={isDescEmptyError || isDescTooLongError}
                        inputRef={descFieldRef}
                        onChange={handleOnChangeDesc}
                        multiline
                        rows={20}
                        helperText={
                            isDescEmptyError
                                ? "Description cannot be empty"
                                : isDescTooLongError
                                    ? "Description cannot be longer than 5000 characters"
                                    : "Max 5000 characters"
                        }
                        sx={CreateDocumentStyle.descriptionTextField}
                    />
                </Box>
                <Box sx={CreateDocumentStyle.buttonBox}>
                    <Button onClick={handleClose} sx={CModalStyle.buttons}>
                        <Clear />
                    </Button>
                    <Button onClick={handleCreateDocument} sx={CModalStyle.buttons}>
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
}