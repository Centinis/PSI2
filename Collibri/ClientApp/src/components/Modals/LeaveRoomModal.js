import React from 'react';
import CModal from "./CModal";
import { Typography } from "@mui/material";
import {deleteModalWarningStyle} from "../../styles/DeleteModalStyle";
import {deleteMember} from "../../api/RoomMemberAPI";
import {useDispatch, useSelector} from "react-redux";
import {setRoomsSlice} from "../../state/user/roomsSlice";
import {CModalStyle} from "../../styles/CModalStyle";


const LeaveRoomModal = (props) => {
  const userInformation = useSelector((state) => state.user);
  const rooms = useSelector((state) => state.rooms);
  const dispatch = useDispatch();
  const handleClose = () => props.setDeleteModal(false);

  const handleChanges = async () => {
    console.log(rooms.currentRoom.id, userInformation.username);
    const data = await deleteMember(rooms.currentRoom.id, userInformation.username)

    if (data === 404) {
      //kazka padaro(alertas ar popup)
    } else {
      dispatch(setRoomsSlice(rooms.rooms.filter(item => item.id !== rooms.currentRoom.id)));
      handleClose();
    }
  };

  return(
    <>
      <CModal handleChanges={handleChanges} handleClose={handleClose} showModal={props.deleteModal} >
        <Typography variant="h5" sx={CModalStyle.text}>
          Are you sure you want to leave legendary "{props.name}"?
        </Typography>
      </CModal>
    </>
  );
}

export default LeaveRoomModal;