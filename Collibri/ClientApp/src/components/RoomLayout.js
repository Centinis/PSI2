import React, { useState } from "react";
import {Button, Grid, Paper} from '@mui/material';
import ParentComponent from "./ParentComponent";
import PostContainer from "./PostContainer";
import Header from "./Header";
import { postContainerStyle } from "../styles/RoomLayoutStyle";
import {AddSection} from "./AddSection";
import {RoomSettings} from "./RoomSettings";


const RoomLayout = () => {
  const [sectionId, setSectionId] = useState(0);
  const [sections, setSections] = useState([]);
  
  return (

    <Grid container spacing={2}
          direction="row"
          justifyContent="space-evenly"
          alignItems="strech">
      <Grid item xs={12}>
        <Paper><Header/></Paper>
      </Grid>
      <Grid item container xs={1} direction="column" justifyContent="space-between">
        <Paper>rooms</Paper>
          <RoomSettings />
      </Grid>
      <Grid item md={4}>
            <AddSection sections={sections} setSections={setSections} ></AddSection>
          <Paper><ParentComponent sections={sections} setSections={setSections} setSectionId={setSectionId} /></Paper>
      </Grid>
      <Grid item xs={6}>
        <Paper sx={postContainerStyle}>
          <PostContainer sectionId={sectionId} />
        </Paper>
      </Grid>
    </Grid>

  );
}

export default RoomLayout;