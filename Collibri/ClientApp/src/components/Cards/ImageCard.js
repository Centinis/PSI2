import React, {useEffect, useState} from 'react';
import {
    Box,
    Card, CardActionArea,
    CardContent,
    CardMedia,
    IconButton, Skeleton, Typography,
} from "@mui/material";
import FileDownloadIcon from '@mui/icons-material/FileDownload';
import DeleteIcon from '@mui/icons-material/Delete';
import {deleteFile, getFile} from "../../api/FileAPI";
import {FileCardStyles} from "../../styles/FileCardStyles"
import DeleteModal from "../Modals/DeleteModal";
import ImageModal from "../Modals/ImageModal";

const ImageCard = (props) => {
    const [imageURL, setImageURL] = useState('');
    const [deleteModal, setDeleteModal] = useState(false);
    const [imageModal, setImageModal] = useState(false);

    useEffect(() => {
        const fetchData = async () => {
            const blobData = await getFile(props.id);
            try {
                const objectURL = URL.createObjectURL(blobData);
                setImageURL(objectURL);
            } catch (error) {
                console.error("Error fetching file data:", error.message);
            }
        };

        fetchData();
    }, [props.id]);
    
    const handleDownload = () => {
        const link = document.createElement('a');
        link.href = imageURL;
        link.setAttribute(
            'download',
            props.name,
        );
        
        document.body.appendChild(link);
        
        link.click();
        
        link.parentNode.removeChild(link);
    }
    
    const handleDelete = (id) => {
        deleteFile(id)
            .then(deletedData => {
                props.setFiles((prevFiles) => prevFiles.filter((file) => file.id !== props.id));
            });
    }
    
    const handleOpenImage = () => {
        setImageModal(true);
    }
    
    return(
        <>
            <Card sx={FileCardStyles.card}>
                {imageURL === ''
                    ? <Skeleton />
                    : <Box>
                        <Box sx={FileCardStyles.imageBox}>
                            <CardActionArea onClick={handleOpenImage}>
                                <CardMedia component="img" alt={props.name} sx={FileCardStyles.media} image={imageURL} />
                            </CardActionArea>
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
                    </Box>}
            </Card>
            <ImageModal open={imageModal} setOpen={setImageModal} imageURL={imageURL} />
            <DeleteModal id={props.id} deleteModal={deleteModal} setDeleteModal={setDeleteModal} handleDelete={handleDelete} />
        </>
    );
    
}

export default ImageCard