import {Button, Box, Divider, IconButton, TextField, Typography, Tooltip} from "@mui/material";
import React, {useRef, useState} from "react";
import {useParams} from "react-router-dom";
import AddBoxIcon from '@mui/icons-material/AddBox';
import DeleteIcon from "@mui/icons-material/Delete";
import CModal from "../Modals/CModal";
import {createSection} from "../../api/SectionApi";
import {RoomLayoutStyle, RoomLayoutStyles} from "../../styles/RoomLayoutStyle";
import {useSelector} from "react-redux";
import {CModalStyle} from "../../styles/CModalStyle";


export const AddSection = ({setSections, sections}) => {
    const nameFieldRef = useRef(null);
    const [open, setOpen] = useState(false);
    const [isEmptyError, setIsEmptyError] = useState(false);
    const [isAlreadyUsedError, setIsAlreadyUsedError] = useState(false);
    const rooms = useSelector((state) => state.rooms);
    const {roomId} = useParams()


    const handleOpen = () => setOpen(true);
    const handleClose = () => {
        setOpen(false);
        setIsEmptyError(false);
        setIsAlreadyUsedError(false);
    }

    const handleOnChange = () => {
        setIsEmptyError(false);
        setIsAlreadyUsedError(false);
    }

    function handleCreateSection() {

        if (nameFieldRef.current.value.trim() === '') {
            setIsEmptyError(true);
            return;
        } else if (sections.some(section => section.sectionName === nameFieldRef.current.value.trim())) {
            setIsAlreadyUsedError(true);
            return;
        } else {
            handleClose();
            createSection(nameFieldRef.current.value.trim(), roomId, setSections);
        }
    }

    return (
        <Box sx={{ height: '13%', display: 'flex', }}>
            <Box sx={{ display: 'flex', justifyContent: 'center', alignItems: 'center', width: '15%', height: '100%'}}>
                <Tooltip title="Add section">
                    <IconButton sx={{...RoomLayoutStyles.addSettingsButtons, color: '#269160'}} color="success" onClick={handleOpen}>
                        <AddBoxIcon fontSize="large"/>
                    </IconButton>
                </Tooltip>
            </Box>
            <Box sx={{ display: 'flex', marginLeft: '1rem', alignItems: 'center', width: '85%', height: '100%'}}>
                <Typography variant="h4" style={RoomLayoutStyle.roomName}>
                    {rooms.currentRoom.name}
                </Typography>
            </Box>
            <CModal showModal={open} handleClose={handleClose} handleChanges={handleCreateSection}>
                <Typography variant="h5" sx={CModalStyle.text}>
                    Create a new Section
                </Typography>
                <TextField fullWidth margin="normal" id="sectionName" label="Section name" variant="outlined"
                           error={isEmptyError || isAlreadyUsedError}
                           inputRef={nameFieldRef}
                           helperText={
                               isEmptyError
                                   ? 'Section name cannot be empty'
                                   : isAlreadyUsedError
                                       ? 'Section name is already used'
                                       : ' '
                           }
                           onChange={handleOnChange} margin="normal"/>
                <Divider/>
            </CModal>
        </Box>
    );
}