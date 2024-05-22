import React, {useState} from "react";
import { Button } from "@mui/material";
import {JoinCreateRoomStyles} from "../../styles/JoinCreateRoomStyles";
import JoinRoomModal from "../Modals/JoinRoomModal";
import {LoginContainerStyles} from "../../styles/LoginContainerStyles";

export const JoinRoom = () => {
    const [joinModal, setJoinModal] = useState(false);
    
    const handleJoinRoom = () => {
        setJoinModal(true);
    }
    
    return (
      <>
          <Button style={{...LoginContainerStyles.button, minWidth:'9rem', maxWidth:'9rem'}} size="large" onClick={() => handleJoinRoom()} variant="contained">Join Room</Button>
          <JoinRoomModal showModal={joinModal} setModal={setJoinModal} />
      </>
    );
}