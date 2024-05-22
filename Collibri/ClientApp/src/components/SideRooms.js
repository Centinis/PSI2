import {Box, Paper, Table, TableBody, TableCell, TableContainer, TableRow, Typography} from "@mui/material";
import {useNavigate} from "react-router-dom";
import {nameCellStyle} from "../styles/tableListStyle";
import {useDispatch, useSelector} from "react-redux";
import {setCurrentRoom} from "../state/user/roomsSlice";
import React, {useState} from "react";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemText from "@mui/material/ListItemText";
import ListItemButton from "@mui/material/ListItemButton";
import {RoomListStyles} from "../styles/RoomListStyles";

export const SideRoomTable = ({ currentRoom }) => {
    const rooms = useSelector((state) => state.rooms);
    const dispatch = useDispatch();
    const [selectedRoom, setSelectedRoom] = useState(null);
    const navigate = useNavigate();

    return (
        <>
            <Box sx={RoomListStyles.roomContainer}>
                <List>
                    {rooms.rooms.map((row) => (
                        <ListItemButton
                            key={row.id}
                            divider="true"
                            onClick={() => {
                                navigate(`/${row.id}`)
                                dispatch(setCurrentRoom(row));
                                setSelectedRoom(row.id);
                            }}
                            sx={{
                                ...RoomListStyles.roomItemButton,
                                ...(selectedRoom === row.id ? RoomListStyles.roomClicked : {}),
                                ...(currentRoom && currentRoom.id === row.id ? RoomListStyles.roomClicked : {}),
                                // Add other styles as needed
                            }}
                        >
                            <ListItemText>
                                <Typography
                                    sx={{
                                        color: '#314231',
                                        ...(selectedRoom === row.id ? RoomListStyles.roomClickedtext : {}),
                                        ...(currentRoom && currentRoom.id === row.id ? RoomListStyles.roomClickedtext : {}),
                                    }}
                                >
                                    {row.name}
                                </Typography>
                            </ListItemText>
                        </ListItemButton>
                    ))}
                </List>
            </Box>
        {/*<TableContainer component={Paper} style={{minHeight: "30rem", maxHeight: "30rem", overflowY: "auto", }}>*/}
        {/*  <Table stickyHeader>*/}
        {/*    <TableBody>*/}
        {/*      {rooms.rooms.map((row) => (*/}
        {/*        <TableRow*/}
        {/*          hover*/}
        {/*          className="TableRow"*/}
        {/*          key={row.id}*/}
        {/*          sx={nameCellStyle}*/}
        {/*        >*/}
        {/*          <TableCell component="th" scope="row"*/}
        {/*                     onClick={() => {*/}
        {/*                       navigate(`/${row.id}`)*/}
        {/*                       dispatch(setCurrentRoom(row));*/}
        {/*                     }}> {row.name} </TableCell>*/}
        {/*        </TableRow>*/}
        {/*      ))}*/}
        {/*    </TableBody>*/}
        {/*  </Table>*/}
        {/*</TableContainer>*/}
      </>
    );
}






