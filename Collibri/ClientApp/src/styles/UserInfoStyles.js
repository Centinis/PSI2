import {styled} from "@mui/material";
import Badge from "@mui/material/Badge";

export const UserInfoStyles = {
    mainBox: {
        // mt:'13vh',
        bgcolor: '#b0e7c8',//a5dcbe
        display:'flex',
        boxShadow: 1,
        height: '10.5%',
        width: '100%',
        // minWidth:'19rem',
        // maxWidth:'15rem'
    },
    iconBox: {
        display: 'flex',
        justifyContent: 'center',
        width: '20%',
        alignItems: 'center',
        // bgcolor: 'background.paper',
        // width:'5rem',
        // paddingTop: '0.75rem',
        // paddingLeft: '1.25rem',
       
    },
    nameBox:{
        display: 'flex',
        // justifyContent: 'center',
        alignItems: 'center',
        width: '80%',
        paddingLeft: '2rem',
        // bgcolor: 'background.paper',
        // // minWidth: '14rem',
        // // paddingTop: '1.25rem',
        // // paddingRight:'1.5rem',
    },
    name: {
        fontWeight: '800',
        color: '#465d4b',
    },
    StyledBadge:  styled(Badge)(({ theme }) => ({
        '& .MuiBadge-badge': {
            backgroundColor: '#FFFFFF',
            color: 'black',
            boxShadow: `0 0 0 2px ${theme.palette.background.paper}`,
            '&::after': {
                position: 'absolute',
                top: 0,
                left: 0,
                width: '100%',
                height: '100%',
                borderRadius: '50%',
                animation: 'ripple 1.2s infinite ease-in-out',
                border: '1px solid currentColor',
                content: '""',
            },
        },
        '@keyframes ripple': {
            '0%': {
                transform: 'scale(.8)',
                opacity: 1,
            },
            '100%': {
                transform: 'scale(2.4)',
                opacity: 0,
            },
        },
    }))
}
 