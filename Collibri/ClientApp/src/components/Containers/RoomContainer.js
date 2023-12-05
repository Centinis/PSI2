import React, {useEffect, useState} from 'react';
import {Box, Button, Paper, Table, TableBody, TableCell, TableContainer, TableRow} from "@mui/material";
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import { useNavigate } from "react-router-dom";
import {deleteRoom, getRooms, updateRoom} from "../../api/RoomAPI";
import UpdateRoomModal from "../Modals/UpdateRoomModal";
import DeleteRoomModal from "../Modals/DeleteRoomModal";
import {buttonStyle, nameCellStyle, tableRowStyle} from "../../styles/tableListStyle";
import {useDispatch, useSelector} from "react-redux";
import {setCurrentRoom, setRoomsSlice} from "../../state/user/roomsSlice";
import LeaveRoomModal from "../Modals/LeaveRoomModal";

export const RoomContainer = () => {

    const [updateModal, setUpdateModal] = useState(false);
    const [deleteModal, setDeleteModal] = useState(false);
    const [room, setRoom] = useState({ "Id": 0, "Name": "default"});
    const userLogInInformation = useSelector((state) => state.user);
    const rooms = useSelector((state) => state.rooms);
    const dispatch = useDispatch();
    const navigate = useNavigate();
    
    const setRoomsSliceFunc = (fetchedData) => {
        dispatch(setRoomsSlice(fetchedData));
    }
    
    const handleOpenUpdateModal = (currentRoom) => {
        setRoom(currentRoom);    
        setUpdateModal(true);
    }
    
    const handleOpenDeleteModal = (currentRoom) => {
        setRoom(currentRoom);
        setDeleteModal(true)
    }
    const updateRoomName = (newName) => {
        room.Name = newName;
        // updateRoom(room.id, room, rooms, setRooms);
    }

    useEffect(() => {
            getRooms(userLogInInformation.username, setRoomsSliceFunc);
        }, []
    );
    
    return (
        <Box>
        <TableContainer component={Paper} style={{ maxHeight: 400 }}>
            <Table stickyHeader sx={{ minWidth:300 }} aria-label="simple table">
                <TableBody>
                    {rooms.rooms.map((row) => (
                        <TableRow
                            hover
                            className="TableRow"
                            key={row.id}
                            sx={tableRowStyle}
                        >
                            <TableCell sx={nameCellStyle} component="th" scope="row" onClick={() => {
                                dispatch(setCurrentRoom(row));
                                navigate(`/${row.id}`)
                            }}> {row.name} </TableCell>
                            
                            <TableCell align="center">
                                <Button sx={buttonStyle} className="Button" onClick={() => {handleOpenDeleteModal(row)}} startIcon={<DeleteIcon style={{fontSize: 25}}/>}></Button>
                            </TableCell>
                            
                            <TableCell align="center">
                                <Button sx={buttonStyle} className="Button" startIcon={<EditIcon style={{fontSize: 25}}/>}
                                    onClick={() => {handleOpenUpdateModal(row)}
                                }></Button>
                            </TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
            <UpdateRoomModal room={room} updateModal={updateModal} setUpdateModal={setUpdateModal} updateRoomName={updateRoomName}/>
            <LeaveRoomModal deleteModal={deleteModal} setDeleteModal={setDeleteModal} />
        </Box>
    );
}