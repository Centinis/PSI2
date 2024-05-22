import {
    Box, Button, Divider, List, ListItemButton, ListItemIcon, ListItemText,
    Modal, TextField, Typography,
} from "@mui/material";
import {ManageTagsModalStyle} from "../../styles/ManageTagsModalStyle";
import {useRef, useState} from "react";
import LocalOfferIcon from '@mui/icons-material/LocalOffer';
import {createTag, deleteTag, getRoomTags} from "../../api/TagAPI";
import {useSelector} from "react-redux";
import AddBoxIcon from '@mui/icons-material/AddBox';
import DeleteIcon from '@mui/icons-material/Delete';

export const ManageTagsModal = (props) => {
    
    const [selectedId, setSelectedId] = useState("");
    const [selectedName, setSelectedName] = useState("");
    const [isEmptyError, setIsEmptyError] = useState(false);
    const [isTooLongError, setIsTooLongError] = useState(false);
    const fieldRef =useRef(null);
    const currentRoom = useSelector((state) => state.rooms.currentRoom);
    
    const handleClose = () => {
        setIsEmptyError(false);
        setIsTooLongError(false);
        setSelectedId("");
        setSelectedName("");
        props.setOpen(false);
    }
    
    const handleOnChange = () => {
        setIsEmptyError(false);

        if (fieldRef.current.value.trim().length > 20) {
            setIsTooLongError(true);
        }
        else {
            setIsTooLongError(false);
        }
    }
    
    const handleAddTag = () => {
        let isOk = true;

        if(fieldRef.current.value.trim() === '')
        {
            setIsEmptyError(true);
            isOk = false;
        }
        if(isTooLongError)
        {
            isOk = false;
        }
        
        if(isOk)
        {
            createTag(JSON.stringify({
                Name: fieldRef.current.value.trim(),
                RoomId: currentRoom.id
            }), props.setTags);
        }
    }
    
    const handleDeleteTag = () => {
        if(selectedId !== "")
        {
            deleteTag(selectedId, props.setTags);
        }
        setSelectedName("");
        setSelectedId("");
    }
    
    return (
        <Modal open={props.showModal} onClose={() => handleClose()}>
            <Box sx={ManageTagsModalStyle.modalWindow}>
                <Box sx={ManageTagsModalStyle.controlBox}>
                    <Box sx={ManageTagsModalStyle.addBox}>
                        <Divider sx={ManageTagsModalStyle.createTagLabel} textAlign="left">
                            <Typography variant="h5">
                                <b>Create a tag</b>
                            </Typography>
                        </Divider>
                        
                        <TextField sx={ManageTagsModalStyle.textField} id="outlined-basic" label="Tag name" variant="standard"
                                   error={isEmptyError || isTooLongError}
                                   inputRef={fieldRef}
                                   onChange={handleOnChange}
                                   helperText={
                                       isEmptyError
                                           ? 'Name cannot be empty'
                                           : isTooLongError
                                               ? 'Name cannot be longer than 20 symbols'
                                               : 'Max 20 symbols'
                                   }
                        />
                        <Button sx={ManageTagsModalStyle.addButton} disableRipple onClick={handleAddTag}>
                            <AddBoxIcon fontSize="large"/>
                        </Button>
                    </Box>
                    <Box>
                        <Divider sx={ManageTagsModalStyle.deleteTagLabel} textAlign="left">
                            <Typography variant="h5">
                                <b>Delete tag</b>
                            </Typography>
                        </Divider>
                        <Box sx={{height: '6.8rem'}}>
                            <Typography sx={ManageTagsModalStyle.toBeDeleted} variant="h6">Selected tag:</Typography>
                            <Typography sx={ManageTagsModalStyle.toBeDeleted} variant="h6"><b>{selectedName}</b></Typography>
                        </Box>
                        
                        <Box sx={{display: 'flex',
                            justifyContent: 'center'}}>
                            <Button disableRipple 
                                    sx={selectedName === "" ? ManageTagsModalStyle.deleteButtonNothingSelected : ManageTagsModalStyle.deleteButton} 
                                    onClick={handleDeleteTag}>
                                <DeleteIcon sx={{fontSize: '5rem'}}/>
                            </Button>
                        </Box>
                        
                    </Box>
                    
                </Box>
                <Box sx={ManageTagsModalStyle.listBox}>
                    <List sx={ManageTagsModalStyle.tagList}>
                        {props.tags.map((tag) => (
                                <ListItemButton
                                    key={tag.id}
                                    selected={selectedId === tag.id}
                                    onClick={() => {setSelectedId(tag.id); setSelectedName(tag.name)}}
                                    sx={ManageTagsModalStyle.tagListItem}
                                >
                                    <ListItemIcon>
                                        <LocalOfferIcon/>
                                    </ListItemIcon>
                                    <ListItemText primary={tag.name}/>
                                </ListItemButton>
                            ))}
                    </List> 
                </Box>
            </Box>
        </Modal>
    );
}