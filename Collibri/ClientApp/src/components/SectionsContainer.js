import React from 'react';
import {Button,Paper,Table,TableRow,TableCell,TableBody,TableContainer} from '@mui/material';
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import {deleteSection, getSections, updateSection} from "../api/SectionApi";
import {useParams} from "react-router-dom";
import UpdateSectionModal from "./UpdateSectionModal";
import '../styles/tableList.css';
import {buttonStyle, nameCellStyle, tableRowStyle} from "../styles/tableListStyle";


const SectionsContainer = ({sections, setSections, setSectionId}) => {
    const [updateModal, setUpdateModal] = useState(false);
    const [section, setSection] = useState({ "Id": 0, "Name": "default"});
    const {roomId} = useParams()
    const handleOpenModal = (currentSection) => {
         setSection(currentSection);
        setUpdateModal(true);
    }

    useEffect(() => {
        getSections(setSections, roomId);
    }, []);

    const handleUpdateSection = (newName) => {
        section.sectionName = newName;
        updateSection(section.sectionId, section, sections, setSections);
    }
   
   
   
    return (
        <>

            <TableContainer component={Paper} style={{maxHeight: 300}}>
                <Table stickyHeader sx={{minWidth: 400}} aria-label="simple table">
                    <TableBody>
                        {sections.map((row) => (
                            <TableRow
                                hover
                                className="TableRow"
                                key={row.sectionId}
                                sx={tableRowStyle}
                            >
                                <TableCell sx={nameCellStyle} component="th" scope="row" onClick={() => setSectionId(row.sectionId)}> {"#" + row.sectionName} </TableCell>
                                <TableCell align="right"><Button startIcon={<DeleteIcon style={{fontSize: 30}}/>}
                                                                 onClick={() => deleteSection(row.sectionId, setSections)}></Button>
                                    <Button sx={buttonStyle} className="Button" startIcon={<EditIcon style={{fontSize: 30}}/>}
                                            onClick={() => {handleOpenModal(row)}
                                            }></Button>
                                </TableCell>

                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
            <UpdateSectionModal section={section} sections={sections} updateModal={updateModal} setUpdateModal={setUpdateModal} updateSection={handleUpdateSection}/>
        </>
    );
};

export default SectionsContainer;