import {Box, Paper, Table, TableBody, TableCell, TableContainer, TableRow} from "@mui/material";
import {useNavigate} from "react-router-dom";
import {nameCellStyle} from "../styles/tableListStyle";
import {useDispatch, useSelector} from "react-redux";
import {setCurrentRoom} from "../state/user/roomsSlice";
import React from "react";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemText from "@mui/material/ListItemText";
import ListItemButton from "@mui/material/ListItemButton";
import {RoomListStyles} from "../styles/RoomListStyles";

export const SideRoomTable = () => {
    const rooms = useSelector((state) => state.rooms);
    const dispatch = useDispatch();
    const navigate = useNavigate();

    return (
      <>
        <Box sx={RoomListStyles.roomContainer}>
            <List>
              {rooms.rooms.map((row) => (
                <ListItemButton
                  // hover
                  // className="TableRow"
                  key={row.id}
                  divider="true"
                  onClick={() => {
                      navigate(`/${row.id}`)
                      dispatch(setCurrentRoom(row));
                  }}
                  // sx={nameCellStyle}
                >
                  <ListItemText> 
                      {row.name} 
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






