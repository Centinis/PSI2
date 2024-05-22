import React from 'react';
import CModal from "./CModal";
import { Typography } from "@mui/material";
import {deleteModalWarningStyle} from "../../styles/DeleteModalStyle";
import {useDispatch, useSelector} from "react-redux";
import {deleteRoom} from "../../api/RoomAPI";
import {setCurrentRoom, setRoomsSlice} from "../../state/user/roomsSlice";
import {CModalStyle} from "../../styles/CModalStyle";

const DeleteRoomModal = (props) => {
    const rooms = useSelector((state) => state.rooms);
    const dispatch = useDispatch();
    
    const handleClose = () => props.setDeleteModal(false);
    
    const handleDeleteRoom = (deletedRoom) => {
        const filteredRooms = rooms.rooms.filter(x => x.id !== deletedRoom.id);
        
        dispatch(setRoomsSlice(filteredRooms));
        if (filteredRooms.length > 0) {
            dispatch(setCurrentRoom(filteredRooms[0]));
            console.log(filteredRooms[0]);
        } else {
            dispatch(setCurrentRoom({
                id: 0,
                name: "",
                invitationCode: 0,
                creatorUsername: ""
            }));
        }
        
        handleClose();
    }
    
    const handleChanges = () => {
        deleteRoom(rooms.currentRoom.id, handleDeleteRoom);
        handleClose();
    };

    return(
        <>
            <CModal handleChanges={handleChanges} handleClose={handleClose} showModal={props.deleteModal} >
                <Typography variant="h5" sx={CModalStyle.text}>
                    Are you sure you want to delete this room?
                </Typography>
                <Typography variant="h6" sx={CModalStyle.text}>
                    {rooms.currentRoom.name}
                </Typography>
                <Typography variant="p" sx={deleteModalWarningStyle}>
                    Deleted rooms cannot be recovered.
                </Typography>
            </CModal>
        </>
    );
}

export default DeleteRoomModal;