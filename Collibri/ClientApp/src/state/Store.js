import { configureStore } from "@reduxjs/toolkit";
import userSlice from "./user/userSlice";
import roomsSlice from "./user/roomsSlice";

export const Store = configureStore({
  reducer: {
    user: userSlice.reducer,
    rooms: roomsSlice.reducer
  }
});