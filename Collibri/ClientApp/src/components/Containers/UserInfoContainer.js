import {Avatar, Box, styled, Typography} from "@mui/material";
import {UserInfoStyles} from "../../styles/UserInfoStyles";
import {useSelector} from "react-redux";


export const UserInfoContainer = () => {
    const userInformation = useSelector((state) => state.user);
  
    return(
        <Box sx={UserInfoStyles.mainBox}>
            <Box sx={UserInfoStyles.iconBox}>
                <Avatar />
            </Box>
            <Box sx={UserInfoStyles.nameBox}>
                <Typography sx={UserInfoStyles.name}>
                  {userInformation.username}
                </Typography>
            </Box>
        </Box>
    );
}
