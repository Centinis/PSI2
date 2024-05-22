import * as React from 'react';
import Paper from '@mui/material/Paper';
import Box from '@mui/material/Box';
import Tab from '@mui/material/Tab';
import Header from "./Header";
import {useState} from "react";
import {Avatar, List, ListItem, Tabs, Typography} from "@mui/material";
import tabStyles from "../styles/TabStyles";
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';

export default function AboutPage()  {
    const [value, setValue] = useState(0); // Assuming you want the default value to be 0 for "item 1"

    const handleChange = (event, newValue) => {
        setValue(newValue);
    };

    return (
        <>
            <Paper>
                <Header />
            </Paper>
            <Box
                sx={{
                    position: 'relative',
                    backgroundImage: `url("/background5.svg")`,
                    backgroundSize: 'cover',
                    backgroundPosition: 'center',
                    transition: 'background-image 0.5s ease-in-out',
                    minHeight: '93vh',
                    display: 'flex',
                    flexDirection: 'column',
                }}
            >
                <Box>
                    <Tabs value={value} onChange={handleChange} centered sx={{backgroundColor: '#B9F5D9'}}>
                        <Tab sx={{ fontSize: '1.25rem', minWidth: "10%" }} label="About Collibri" />
                        <Tab sx={{ fontSize: '1.25rem', minWidth: "10%" }} label="FAQ" />
                        <Tab sx={{ fontSize: '1.25rem', minWidth: "10%" }} label="Reviews" />
                    </Tabs>
                </Box>
                <Box px={3}>
                    <TabPanel value={value} index={0}>{aboutTab()}</TabPanel>
                    <TabPanel value={value} index={1}>{FAQ()}</TabPanel>
                    <TabPanel value={value} index={2}>{Reviews()}</TabPanel>
                </Box>
            </Box>
        </>
    );
}

function TabPanel(props) {
    const { children, value, index } = props;
    return (
        <Box>
            {value === index && (<h1>{children}</h1>)}
        </Box>
    );
}

export const aboutTab = () =>{
    
    return(
        <Box
            display="flex"
            flexDirection="column"
            alignItems="center"
            maxHeight="100vh"
            maxWidth="100vh"    
            sx={tabStyles.background}>
            <Typography align='center' sx={{...tabStyles.mainTabs, paddingTop: '3rem', fontFamily: 'Segoe UI semibold'}} variant={"h4"}>Collibri: Where knowledge takes flight.</Typography>
            <Box mb={4} />
            <Typography sx={{...tabStyles.mainTabs, fontSize : '1.5rem', paddingBottom: '3rem'}} variant={"h6"}>Collibri is a no-frills restricted-access website created for a university course project, specializing in sharing notes for various courses. It was initiated in 2023 to meet the requirements of the course project, aiming to provide a straightforward and user-friendly platform for students.
                <Box mb={4} />
                Focusing on the practical need for note-sharing, Collibri serves as a hub where students can easily exchange and access study materials related to different courses. While it may lack the sophistication of larger platforms, Colibri's simplicity is intentional, prioritizing functionality for the benefit of its users in navigating the academic landscape.</Typography>
        </Box>
        
        
    );
}
export const FAQ = () => {
    const faqData = [
        {
            question: 'What is Collibri?',
            answer: 'Collibri is a student Colaboration website. It\'s a place where students of all fields can share posts, notes, documents, and files with one another.',
        },
        {
            question: 'How can I share my notes?',
            answer: 'Collibri has a room-section-posts system. To upload content (document, file, image), you must be in a designated room, have selected a certain section and add a post. In the post, you can add a small note, a larger document, or even upload photos or files!',
        },
        {
            question: 'How do I invite others to view or collaborate on my notes?',
            answer: 'Other people can see your notes if they join your room. All they need is to click join room and input the code of said room.',
        },
        {
            question: 'What file formats are supported for uploading?',
            answer: 'You can upload any format file, however it has to be under 5 MB',
        },
        {
            question: 'Is there a search feature to find specific information? ',
            answer: 'Yes! there is a search bar above posts where you can find the types of posts that interest you.',
        },
        {
            question: 'How can I recover my account if I forget my password?',
            answer: 'All you need to do is press the forget password button and follow the instructions.',
        },
        // Add more FAQ items as needed
    ];

    const [openIndices, setOpenIndices] = useState([]);

    const handleQuestionClick = (index) => {
        setOpenIndices((prevOpenIndices) => {
            const isOpen = prevOpenIndices.includes(index);
            return isOpen
                ? prevOpenIndices.filter((i) => i !== index)
                : [...prevOpenIndices, index];
        });
    };

    return (
        <Box
            display="flex"
            flexDirection="column"
            alignItems="center"
            maxWidth="100vh"
            sx={{...tabStyles.background, marginBottom: '4rem'}}
        >
            {/*<Typography*/}
            {/*    sx={{ paddingTop: '3rem', paddingBottom: '3rem', fontSize: '1.25rem' }}*/}
            {/*    variant="h5"*/}
            {/*>*/}
            {/*    Below are some frequently asked questions about Collibri:*/}
            {/*</Typography>*/}
            <Box sx={{marginBottom: '3rem', marginTop: '4rem'}}>
                {faqData.map((faq, index) => (
                    <Box
                        key={index}
                        textAlign="left"
                        overflow="hidden"
                        transition="height 0.3s"
                        maxWidth="61.83vh"
                        sx={{
                            ...tabStyles.questionBox,
                            breakInside: 'avoid',
                            marginBottom: '1rem',
                            display: 'flex',
                            flexDirection: 'column',
                        }}
                    >
                        <Typography
                            onClick={() => handleQuestionClick(index)}
                            sx={{ cursor: 'pointer', fontSize: '1.2rem', fontWeight: 'bold', display: 'flex', alignItems: 'center' }}
                        >
                            {faq.question}
                            <ExpandMoreIcon
                                sx={{
                                    marginLeft: 'auto',
                                    transform: openIndices.includes(index) ? 'rotate(180deg)' : 'rotate(0deg)',
                                }}
                            />
                        </Typography>
                        {openIndices.includes(index) && (
                            <Typography sx={{ marginTop: '1rem' }}>
                                {faq.answer}
                            </Typography>
                        )}
                    </Box>
                ))}
            </Box>
        </Box>
    );
};
export const Reviews = () => {
    const comments = [
        {
            avatarColor: 'orange',
            avatarText: 'DK',
            commentText: '"The best website I have ever seen"',
        },
        {
            avatarColor: 'turquoise',
            avatarText: 'MM',
            commentText: '"I really enjoy using this website, I\'m going to recommend it to all my friends"',
        },
        {
            avatarColor: 'red',
            avatarText: 'JV',
            commentText:
                '"I enjoy using Collibri for its functionality, but a dark mode option would be a great addition. It\'s easier on the eyes during late-night study sessions. Hoping the developers consider this for future updates!"',
        },
        {
            avatarColor: 'red',
            avatarText: 'GPT',
            commentText:
                '"Collibri is a fantastic platform for note-sharing, but it would be even better with a dedicated mobile app. Having on-the-go access to my notes would be incredibly convenient. Hope to see this feature in the future!"',
        },
    ];

    return (
        <Box
            display="flex"
            flexDirection="row" // Change 'column' to 'row'
            alignItems="center"
            maxWidth="150vh"
            sx={{ ...tabStyles.background, marginLeft: '12.5%', paddingTop: 0 }}
        >
            <Box sx={{ maxWidth: '150vh', overflowY: 'auto', padding: '4rem' }}>
                <List sx={{ ...tabStyles.reviews, paddingBottom: '1rem', display: 'block' }}>
                    {comments.map((comment, index) => (
                        <ListItem key={index} sx={{ ...tabStyles.commentBox }}>
                            <Avatar sx={{ bgcolor: comment.avatarColor, height: 50, width: 50 }}>
                                {comment.avatarText}
                            </Avatar>
                            <Typography sx={tabStyles.comments}>{comment.commentText}</Typography>
                        </ListItem>
                    ))}
                </List>
            </Box>
        </Box>
    );
};
