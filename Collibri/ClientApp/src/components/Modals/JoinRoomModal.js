import React, {useRef, useState} from 'react';
import {TextField, Typography} from "@mui/material";
import {deleteModalWarningStyle} from "../../styles/DeleteModalStyle";
import CModal from "./CModal";
import {modalTextField} from "../../styles/UpdatePostModalStyle";
import {useDispatch, useSelector} from "react-redux";
import {createMember} from "../../api/RoomMemberAPI";
import {addRoomSlice} from "../../state/user/roomsSlice";
import {getRoomByCode} from "../../api/RoomAPI";
import {CModalStyle} from "../../styles/CModalStyle";

const JoinRoomModal = (props) => {
  const textFieldRef = useRef(null);
  const [error, setError] = useState({
    isError: false,
    message: '',
  });
  const rooms = useSelector((state) => state.rooms.rooms);
  const userInformation = useSelector((state) => state.user);
  const dispatch = useDispatch();
  
  const handleClose = () => {
    setError({ isError: false, message: '' });
    props.setModal(false);
  }
  
  const handleChanges = async () => {
    const invitationCodes = rooms.map(x => x.invitationCode);
    const code = parseInt(textFieldRef.current.value);
    
    if (!isNaN(code)) {
      if (invitationCodes.includes(code)) {
        setError({ isError: true, message: "You've already joined this room!" });
      } else {
        const data = await createMember({roomId: 0, username: userInformation.username}, textFieldRef.current.value); //gali mest null del missing field

        if (data === 404) {
          setError({ isError: true, message: "Room doesn't exist" });
        } else {
          const data = await getRoomByCode(code);
          
          if (data === 404) {
            console.log("reikia kad rodytu erroras jei kazkas kazkaip feilina");
            // reikia kad rodytu erroras jei kazkas kazkaip feilina
          } else {
            dispatch(addRoomSlice(data));
          }
          handleClose();
        }
      }
    } else {
      setError({ isError: true, message: "Code must be a number!" });
    }
  };

  return(
    <>
      <CModal handleChanges={handleChanges} handleClose={handleClose} showModal={props.showModal} >
        <Typography variant="h5" sx={CModalStyle.text}>
          Enter the invitation code
        </Typography>
        <TextField
          error={error.isError}
          inputRef={textFieldRef}
          size='small'
          helperText={error.isError ? error.message : ' '}
          sx={modalTextField}
        />
      </CModal>
    </>
  );
}

export default JoinRoomModal;