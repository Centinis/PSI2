import React, {useState} from 'react';
import {Box, Card, CardContent, Fade, IconButton, Tooltip, Typography} from "@mui/material";

import {
  ThumbUp,
  ThumbUpAltOutlined,
  ThumbDown,
  ThumbDownAltOutlined,
  Edit,
  Delete, CloseOutlined, MoreVertOutlined, FileDownloadOutlined
} from "@mui/icons-material";
import {NoteCardStyles} from "../../styles/NoteCardStyles";
import {deleteNote} from "../../api/NoteAPI";
import DeleteModal from "../Modals/DeleteModal";


const NoteCard = (props) => {
  const [moreButton, setMoreButton] = useState(false);
  const [deleteModal, setDeleteModal] = useState(false);
  
  const handleDelete = (id) => {
    deleteNote(id)
      .then(r => props.setNotes((prevNotes) => prevNotes.filter(x => x.id !== r.id)))
    setMoreButton(false);
  }
  
  return (
    <Card sx={NoteCardStyles.card}>
      <CardContent>
        <Box sx={NoteCardStyles.contentBox}>
          <Box>
            <Tooltip
              TransitionComponent={Fade}
              placement="top-start"
              title={props.name}>
              <Typography sx={{...NoteCardStyles.generalText, ...NoteCardStyles.title}} variant="h6">
                {props.name}
              </Typography>
            </Tooltip>
            <Box>
              <Typography sx={{...NoteCardStyles.generalText, ...NoteCardStyles.content}} variant="body2">
                {props.text}
              </Typography>
            </Box>
          </Box>
          <Box>
            {moreButton ? (
              <>
                {/*<IconButton>*/}
                {/*  <Edit />*/}
                {/*</IconButton>*/}
                <IconButton onClick={() => setDeleteModal(true)}>
                  <Delete />
                </IconButton>
                <IconButton onClick={() => setMoreButton(false)}>
                  <CloseOutlined />
                </IconButton>
              </>
            ) : (
              <>
                <IconButton onClick={() => setMoreButton(true)}>
                  <MoreVertOutlined />
                </IconButton>
              </>
            )
            }
          </Box>
          <DeleteModal deleteModal={deleteModal} setDeleteModal={setDeleteModal} handleDelete={handleDelete} id={props.id}/>
        </Box>
      </CardContent>
    </Card>
  );
}

export default NoteCard;