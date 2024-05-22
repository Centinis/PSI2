import React, {useEffect, useState} from 'react';
import {
    Box,
    Button,
    IconButton,
    Paper,
    styled,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableRow, Tooltip
} from "@mui/material";
import DeleteIcon from '@mui/icons-material/Delete';
import { useNavigate } from "react-router-dom";
import {deleteRoom, getRooms, updateRoom} from "../../api/RoomAPI";
import {
    buttonStyle,
    deleteButtonStyle,
    nameCellStyle,
    SectionsContainerStyles,
    tableRowStyle
} from "../../styles/tableListStyle";
import {useDispatch, useSelector} from "react-redux";
import {setCurrentRoom, setRoomsSlice, updateRoomsSlice} from "../../state/user/roomsSlice";
import LeaveRoomModal from "../Modals/LeaveRoomModal";
import {RoomTable} from "../../styles/RoomContainer";
import ExitToAppIcon from '@mui/icons-material/ExitToApp';

export const RoomContainer = () => {
    const [deleteModal, setDeleteModal] = useState(false);
    const [room, setRoom] = useState({ id: 0, name: "", creatorUsername: "", invitationCode: 0 });
    const userLogInInformation = useSelector((state) => state.user);
    const rooms = useSelector((state) => state.rooms);
    const dispatch = useDispatch();
    const navigate = useNavigate();
    
    const setRoomsSliceFunc = (fetchedData) => {
        dispatch(setRoomsSlice(fetchedData));
    }
    
    const handleOpenDeleteModal = (currentRoom) => {
        dispatch(setCurrentRoom(currentRoom));
        setRoom(currentRoom);
        setDeleteModal(true);
    }

    useEffect(() => {
            getRooms(userLogInInformation.username, setRoomsSliceFunc);
        }, []
    );
    const TextOnlyTooltip = styled(({className, ...props}) => (
        <Tooltip {...props} componentsProps={{tooltip: {className: className}}}/>
        ))(`
        color: black;
        background-color: transparent;
    `);
    
    return (
        <Box>
        <TableContainer component={Paper} elevation={0} sx={RoomTable.container}>
            <Table stickyHeader sx={{ minWidth:300}} aria-label="simple table">
                <TableBody>
                    {rooms.rooms.map((row) => (
                        <TableRow
                            className="TableRow"
                            key={row.id}
                            sx={{
                                transition: 'background-color 0.4s ease-in-out',
                                '&:hover': {
                                    backgroundColor: 'rgba(140,225,174,0.61)',
                                },
                            }}
                        >
                            <TableCell sx={nameCellStyle} component="th" scope="row" onClick={() => {
                                dispatch(setCurrentRoom(row));
                                navigate(`/${row.id}`)
                            }}> {row.name} </TableCell>
                            
                            <TableCell align="center">
                                <IconButton
                                    sx={{visibility: 'hidden'}}
                                    className="Button"
                                    onClick={() => { handleOpenDeleteModal(row) }}
                                    style={{ transition: 'background-color 0.3s ease' }}
                                    onMouseOver={(e) => { e.currentTarget.style.boxShadow = '0px 8px 15px rgba(0, 0, 0, 0.4)' }}
                                    onMouseOut={(e) => { e.currentTarget.style.boxShadow = '0px 2px 5px rgba(0, 0, 0, 0.2)' }}
                                >
                                    <TextOnlyTooltip placement="left" title="Leave Room"
                                                     sx={{fontSize: '0.75rem', backgroundColor: 'white'}}>
                                    <ExitToAppIcon style={{ fontSize: 25 }} />
                                    </TextOnlyTooltip>
                                </IconButton>
                                {/*<Button sx={buttonStyle} className="Button" onClick={() => {handleOpenDeleteModal(row)}} startIcon={<DeleteIcon style={{fontSize: 25}}/>}></Button>*/}
                            </TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
            <LeaveRoomModal name={room.name} deleteModal={deleteModal} setDeleteModal={setDeleteModal} />
        </Box>
    );
}