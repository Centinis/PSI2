import {
    Box,
    Button,
    Chip,
    Grid,
    IconButton,
    List,
    ListItem,
    Menu,
    MenuItem,
    Modal,
    TextField,
    Typography
} from "@mui/material";
import {useRef, useState} from "react";
import {Check, Clear} from "@mui/icons-material";
import {CreatePostStyle} from "../../styles/CreatePostStyle";
import {createPost} from "../../api/PostAPI";
import {useSelector} from "react-redux";
import {CModalStyle} from "../../styles/CModalStyle";
import AddBoxIcon from "@mui/icons-material/AddBox";
import CloseIcon from "@mui/icons-material/Close";
import {addToPost} from "../../api/TagAPI";

export const CreatePostModal = (props) => {

    const titleFieldRef = useRef(null);
    const descFieldRef = useRef(null);
    const [isTitleEmptyError, setIsTitleEmptyError] = useState(false);
    const [isDescEmptyError, setIsDescEmptyError] = useState(false);
    const [isTitleTooLongError, setIsTitleTooLongError] = useState(false);
    const [isDescTooLongError, setIsDescTooLongError] = useState(false);
    const [selectedTags, setSelectedTags] = useState([]);
    const [anchorEl, setAnchorEl] = useState(null);
    const userInformation = useSelector((state) => state.user);

    const openMenu = Boolean(anchorEl);
    const handleClick = (event) => {
        setAnchorEl(event.currentTarget);
    };
    const handleCloseMenu = () => {
        setAnchorEl(null);
    };
    const handleOnChangeTitle = () => {
        setIsTitleEmptyError(false);
        
        if (titleFieldRef.current.value.trim().length > 20) {
            setIsTitleTooLongError(true);
        }
        else {
            setIsTitleTooLongError(false);
        }
    }

    const handleOnChangeDesc = () => {
        setIsDescEmptyError(false);

        if (descFieldRef.current.value.trim().length > 350) {
            setIsDescTooLongError(true);
        }
        else {
            setIsDescTooLongError(false);
        }
    }
    
    async function handleCreatePost() {
        let isOk = true;
        
        if (titleFieldRef.current.value.trim() === '') {
            setIsTitleEmptyError(true);
            isOk = false;
        }
        if (descFieldRef.current.value.trim() === '') {
            setIsDescEmptyError(true);
            isOk = false;
        }
        if(isTitleTooLongError) {
            isOk = false;
        }
        if(isDescTooLongError) {
            isOk = false;
        }
        
        if (isOk) {
            createPost(JSON.stringify({
                Title: titleFieldRef.current.value.trim(),
                Description: descFieldRef.current.value.trim(),
                SectionId: props.sectionId,
                CreatorUsername: userInformation.username
            }), props.setPosts, props.addNewPost).then(post => {
                console.log(selectedTags);
                selectedTags.forEach(tag => addToPost(tag.id, post.id));
            })
            setSelectedTags([]);
            props.setOpen(false);
        }
    }
    
    const handleAddTag = (tag) => {
        if(!selectedTags.some(t => t.id === tag.id))
        {
            setSelectedTags(prevTags => [...prevTags, tag]);
        }
    }
    
    const handleRemoveTag = (tag) => {
        setSelectedTags(prevTags => prevTags.filter(t => t.id !== tag.id));
    }

    const handleClose = () => {
        setIsTitleEmptyError(false);
        setIsTitleTooLongError(false);
        setIsDescEmptyError(false);
        setIsDescTooLongError(false);
        setSelectedTags([]);
        
        props.setOpen(false);
    }
    
    return (
        <Modal open={props.showModal} onClose={() => handleClose()}>
            <Box sx={CreatePostStyle.modalWindow}
                 align="center"
            >
                <Typography variant='h4' sx={[CModalStyle.text, {marginBottom: '5%'}]}>
                    Create a post
                </Typography>
                <Box sx={CreatePostStyle.textFieldBox}>
                    <TextField label="Post title" variant="standard" multiline
                               error={isTitleEmptyError || isTitleTooLongError}
                               inputRef={titleFieldRef}
                               onChange={handleOnChangeTitle}
                               helperText={
                                   isTitleEmptyError
                                       ? 'Title cannot be empty'
                                       : isTitleTooLongError 
                                            ? 'Title cannot be longer than 20 symbols' 
                                            : 'Max 20 symbols'
                               }
                               sx={CreatePostStyle.nameTextField}/>
                </Box>
                <Box sx={CreatePostStyle.textFieldBox}>
                    <TextField id="outlined-basic" label="Post description" variant="outlined"
                               error={isDescEmptyError || isDescTooLongError}
                               inputRef={descFieldRef}
                               onChange={handleOnChangeDesc}
                               multiline
                               rows={7}
                               helperText={
                                   isDescEmptyError
                                       ? 'Description cannot be empty'
                                       : isDescTooLongError 
                                            ? 'Description cannot be longer than 350 symbols' 
                                            : 'Max 350 symbols'
                               }
                               sx={CreatePostStyle.descriptionTextField}/>
                </Box>
                <Typography variant='h5' sx={[CModalStyle.text, {marginTop: '2%', marginBottom: '2%'}]}>
                    Add tags
                </Typography>
                <Box sx={CreatePostStyle.addTagsBox}>
                    <List dense sx={CreatePostStyle.tagList}>
                        {selectedTags.map((tag) => (
                            <ListItem sx={CreatePostStyle.tagListItem}>
                                <Chip label={tag.name}></Chip>
                                <IconButton onClick={() => handleRemoveTag(tag)}><CloseIcon/></IconButton>
                            </ListItem>
                        ))}
                    </List>
                    
                    <Button disableRipple sx={CreatePostStyle.tagMenuButton} onClick={handleClick}>
                        <AddBoxIcon fontSize="large"></AddBoxIcon>
                    </Button>
                    <Menu
                        id="basic-menu"
                        anchorEl={anchorEl}
                        open={openMenu}
                        onClose={handleCloseMenu}
                        sx={CreatePostStyle.tagMenu}
                    >
                        {props.tags.map((tag) => (
                            <MenuItem onClick={() => handleAddTag(tag)}>
                                {tag.name}
                            </MenuItem>
                        ))}
                    </Menu>
                </Box>
                <Typography sx={[CreatePostStyle.warningNote, CModalStyle.text]}>
                    Creating a post will allow you to add documents, notes and files.
                </Typography>
                <Box>
                    <Button onClick={handleClose} sx={CreatePostStyle.button}><Clear/></Button>
                    <Button onClick={handleCreatePost} sx={CreatePostStyle.button}><Check/></Button>
                </Box>
            </Box>
        </Modal>
    );
}