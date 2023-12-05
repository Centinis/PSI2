import React from 'react';
import CModal from "./CModal";
import { Typography } from "@mui/material";
import {deleteModalWarningStyle} from "../../styles/DeleteModalStyle";
import {deleteMember} from "../../api/RoomMemberAPI";
import {useDispatch, useSelector} from "react-redux";
import {setRoomsSlice} from "../../state/user/roomsSlice";


const LeaveRoomModal = (props) => {
  const userInformation = useSelector((state) => state.user);
  const rooms = useSelector((state) => state.rooms);
  const dispatch = useDispatch();
  const handleClose = () => props.setDeleteModal(false);

  const handleChanges = async () => {
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
        <Typography variant="h5">
          Are you sure you want to leave legendary "{rooms.currentRoom.name}"?
        </Typography>
      </CModal>
    </>
  );
}

export default LeaveRoomModal;