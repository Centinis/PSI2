import {createSlice} from "@reduxjs/toolkit";

const initialState = {
  username: "",
  loggedIn: false
}

const userSlice = createSlice({
  name: "user",
  initialState,
  reducers: {
    onLogin: (state, action) => {
      state.username = action.payload;
      state.loggedIn = true;
    },
    onLogout: () => initialState,
  }
});

export const { onLogin, onLogout } = userSlice.actions;
export default userSlice;