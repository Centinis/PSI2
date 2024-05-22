import React, {useState} from 'react';
import {Box, Card, CardContent, CardMedia, IconButton, Skeleton, Typography} from "@mui/material";
import {FileCardStyles} from "../../styles/FileCardStyles"
import {deleteFile, getFile} from "../../api/FileAPI";
import FileDownloadIcon from "@mui/icons-material/FileDownload";
import DeleteIcon from "@mui/icons-material/Delete";
import DescriptionIcon from '@mui/icons-material/Description';
import DeleteModal from "../Modals/DeleteModal";

const FileCard = (props) => {
    const [deleteModal, setDeleteModal] = useState(false);

    const handleDownload = async() => {
        const blobData = await getFile(props.id);
        try {
            const objectURL = URL.createObjectURL(blobData);
            const link = document.createElement('a');
            link.href = objectURL;
            link.setAttribute(
                'download',
                props.name,
            );

            document.body.appendChild(link);

            link.click();

            link.parentNode.removeChild(link);
        } catch (error) {
            console.error("Error fetching file data:", error.message);
        }
    }
    
    const handleDelete = (id) => {
        deleteFile(id)
            .then(deletedData => {
                props.setFiles((prevFiles) => prevFiles.filter((file) => file.id !== props.id));
            });
    }
    
    return (
        <>
            <Card sx={FileCardStyles.card}>
                <Box sx={FileCardStyles.imageBox}>
                    <DescriptionIcon sx={FileCardStyles.fileImage} />
                </Box>
                <CardContent sx={FileCardStyles.content}>
                    <Box sx={FileCardStyles.nameBox}>
                        <Typography sx={FileCardStyles.fileName}>{props.name}</Typography>
                    </Box>
                    <Box sx={FileCardStyles.buttons}>
                        <IconButton onClick={handleDownload}>
                            <FileDownloadIcon />
                        </IconButton>
                        <IconButton onClick={(event) => {
                            event.stopPropagation();
                            setDeleteModal(true);
                        }}>
                            <DeleteIcon />
                        </IconButton>
                    </Box>
                </CardContent>
            </Card>
            <DeleteModal id={props.id} deleteModal={deleteModal} setDeleteModal={setDeleteModal} handleDelete={handleDelete} />
        </>
    );
    
}

export default FileCard;