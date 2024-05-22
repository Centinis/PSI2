import React, {useState} from 'react';
import {
  Box,
  Card,
  CardActionArea,
  CardActions,
  CardContent,
  Fade,
  Icon,
  IconButton,
  Tooltip,
  Typography
} from "@mui/material";
import {
  Edit,
  Delete, FileDownload, FileDownloadOutlined, MoreVertOutlined, Close, CloseOutlined
} from "@mui/icons-material";
import {deleteDocument} from "../../api/DocumentAPI";
import DeleteModal from "../Modals/DeleteModal";
import DocumentModal from "../Modals/DocumentModal";
import {DocumentCardStyles} from "../../styles/DocumentCardStyles";

const DocumentCard = (props) => {
  const [moreButton, setMoreButton] = useState(false);
  const [deleteModal, setDeleteModal] = useState(false);
  const [documentModal, setDocumentModal] = useState(false);
  
  const handleDelete = () => {
    deleteDocument(props.id)
      .then(deletedDoc => {
        props.setDocuments((prevDocuments) => (prevDocuments.filter(x => x.id !== deletedDoc.id)));
      })
    setMoreButton(false);
  }
  
  return (
    <>
      <Card sx={DocumentCardStyles.card}>
          <CardActionArea disableRipple sx={DocumentCardStyles.cardActionArea} onClick={() => {
              setDocumentModal(true);
          }}>
              <CardContent>
                  <Box sx={DocumentCardStyles.contentBox}>
                      <Box>
                          <Tooltip
                              TransitionComponent={Fade}
                              placement="top-start"
                              title={props.title}>
                              <Typography sx={{...DocumentCardStyles.generalText, ...DocumentCardStyles.title}} variant="h6">
                                  {props.title}
                              </Typography>
                          </Tooltip>
                          <Box>
                              <Typography sx={{...DocumentCardStyles.generalText, ...DocumentCardStyles.content}} variant="body2">
                                  {props.text}
                              </Typography>
                          </Box>
                      </Box>
                  </Box>
              </CardContent>
          </CardActionArea>
          <CardActions >
              <Box sx={{display: 'flex', flexDirection: 'column'}}>
                  {moreButton ? (
                      <>
                          {/*<IconButton>*/}
                          {/*    <Edit />*/}
                          {/*</IconButton>*/}
                          <IconButton onClick={() => setDeleteModal(true)}>
                              <Delete />
                          </IconButton>
                          <IconButton>
                              <CloseOutlined onClick={() => setMoreButton(false)} />
                          </IconButton>
                      </>
                  ) : (
                      <>
                          <IconButton onClick={() => setMoreButton(true)}>
                              <MoreVertOutlined />
                          </IconButton>
                          {/*<IconButton>*/}
                          {/*    <FileDownloadOutlined />*/}
                          {/*</IconButton>*/}
                      </>
                  )
                  }
              </Box>
          </CardActions>
      </Card>
      <DeleteModal id={props.id} handleDelete={handleDelete} deleteModal={deleteModal} setDeleteModal={setDeleteModal} />
      <DocumentModal id={props.id} title={props.title} text={props.text} documentModal={documentModal} setDocumentModal={setDocumentModal}/>
    </>
  );
}

export default DocumentCard;