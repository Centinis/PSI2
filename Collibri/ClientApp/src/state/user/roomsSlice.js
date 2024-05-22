import {createSlice} from "@reduxjs/toolkit";
import {Room} from "@mui/icons-material";

const initialState = {
  rooms: [''],
  currentRoom: {
    id: 0,
    name: "",
    invitationCode: 0,
    creatorUsername: ""
  }
}

const roomsSlice = createSlice({
  name: "rooms",
  initialState,
  reducers: {
    setRoomsSlice: (state, action) => {
      state.rooms = action.payload;
    },
    addRoomSlice: (state, action) => {
      state.rooms = [...state.rooms, action.payload];
    },
    setCurrentRoom: (state, action) => {
      state.currentRoom = action.payload;
    }
  }  
});

export const { setRoomsSlice, addRoomSlice, setCurrentRoom, updateRoomSlice } = roomsSlice.actions;
export default roomsSlice;