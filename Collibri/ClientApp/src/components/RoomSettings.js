import React, { useState } from "react";
import {
    IconButton,
    Tooltip,
    Box,
    Collapse,
} from "@mui/material";
import MoreVertRoundedIcon from "@mui/icons-material/MoreVertRounded";
import DriveFileRenameOutlineIcon from "@mui/icons-material/DriveFileRenameOutline";
import PersonAddIcon from "@mui/icons-material/PersonAdd";
import DeleteIcon from "@mui/icons-material/Delete";
import LocalOfferIcon from "@mui/icons-material/LocalOffer";
import { RoomLayoutStyles } from "../styles/RoomLayoutStyle";
import RoomCodeModal from "./Modals/RoomCodeModal";
import { useDispatch, useSelector } from "react-redux";
import DeleteRoomModal from "./Modals/DeleteRoomModal";
import UpdateRoomModal from "./Modals/UpdateRoomModal";
import { updateRoom } from "../api/RoomAPI";
import { setRoomsSlice } from "../state/user/roomsSlice";
import { ManageTagsModal } from "./Modals/ManageTagsModal";

export const RoomSettings = (props) => {
    const [updateModal, setUpdateModal] = useState(false);
    const [invModal, setInvModal] = useState(false);
    const [deleteModal, setDeleteModal] = useState(false);
    const [tagOpen, setTagOpen] = useState(false);
    const [showSettings, setShowSettings] = useState(false);
    const userInformation = useSelector((state) => state.user);
    const rooms = useSelector((state) => state.rooms);
    const dispatch = useDispatch();

    const handleInvitation = () => {
        setInvModal(true);
    };

    const updateCurrentRooms = (data) => {
        const updatedRooms = rooms.rooms.map((x) => {
            if (x.id === data.id) {
                return data;
            } else {
                return x;
            }
        });
        dispatch(setRoomsSlice(updatedRooms));
    };

    const handleUpdateRoom = (newName) => {
        const updatedRoom = {
            ...rooms.currentRoom,
            name: newName,
        };
        updateRoom(rooms.currentRoom.id, updatedRoom, updateCurrentRooms);
    };

    const handleDeleteRoom = () => {
        setDeleteModal(true);
    };

    const handleManageTags = () => {
        setTagOpen(true);
    };

    const toggleSettings = () => {
        setShowSettings((prev) => !prev);
    };

    return (
        <>
            <Tooltip title="Room settings">
                <IconButton
                    sx={RoomLayoutStyles.addSettingsButtons}
                    aria-label="Toggle Settings"
                    onClick={toggleSettings}
                >
                    <MoreVertRoundedIcon />
                </IconButton>
            </Tooltip>

            <Collapse
                in={showSettings}
                timeout="auto"
                style={{
                    transform: showSettings ? 'translateX(0)' : 'translateX(-100%)',
                    transition: "transform 0.3s ease-in-out",
                }}
            >
                <Box sx={RoomLayoutStyles.addSettingsButtons}>
                    <Tooltip title="Get invitation code">
                        <IconButton
                            aria-label="Get invitation code"
                            onClick={() => handleInvitation()}
                        >
                            <PersonAddIcon />
                        </IconButton>
                    </Tooltip>

                    <Tooltip title="Change Room Name">
                        <IconButton
                            aria-label="Change Room Name"
                            disabled={
                                rooms.currentRoom.creatorUsername !== userInformation.username
                            }
                            onClick={() => setUpdateModal(true)}
                        >
                            <DriveFileRenameOutlineIcon />
                        </IconButton>
                    </Tooltip>

                    <Tooltip title="Manage Tags">
                        <IconButton
                            aria-label="Manage Tags"
                            onClick={() => handleManageTags()}
                        >
                            <LocalOfferIcon />
                        </IconButton>
                    </Tooltip>

                    <Tooltip title="Delete Room">
                        <IconButton
                            aria-label="Delete Room"
                            disabled={
                                rooms.currentRoom.creatorUsername !== userInformation.username
                            }
                            onClick={() => handleDeleteRoom()}
                        >
                            <DeleteIcon />
                        </IconButton>
                    </Tooltip>
                </Box>
            </Collapse>

            <RoomCodeModal
                invModal={invModal}
                setInvModal={setInvModal}
                anchorClose={() => {}}
            />
            <UpdateRoomModal
                room={rooms.currentRoom}
                updateModal={updateModal}
                setUpdateModal={setUpdateModal}
                updateRoomName={handleUpdateRoom}
            />
            <DeleteRoomModal
                deleteModal={deleteModal}
                setDeleteModal={setDeleteModal}
            />
            <ManageTagsModal
                showModal={tagOpen}
                setOpen={setTagOpen}
                tags={props.tags}
                setTags={props.setTags}
            />
        </>
    );
};
