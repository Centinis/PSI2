import React, {useEffect, useState} from 'react';
import {
    Button,
    Paper,
    Table,
    TableRow,
    TableCell,
    TableBody,
    TableContainer,
    Box,
    Typography,
    IconButton
} from '@mui/material';
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import {useParams} from "react-router-dom";
import '../../styles/tableList.css';
import {deleteSection, updateSection} from "../../api/SectionApi";
import UpdateSectionModal from "../Modals/UpdateSectionModal";
import {
    deleteButtonStyle, editButtonStyle,
    nameCellStyle,
    SectionsContainerStyles,
} from "../../styles/tableListStyle";
import {useSelector} from "react-redux";
import {RoomLayoutStyle} from "../../styles/RoomLayoutStyle";



const SectionsContainer = ({sections, setSections, setSectionId}) => {
    const [updateModal, setUpdateModal] = useState(false);
    const [isHovered, setIsHovered] = useState(null);
    const [isSelected, setIsSelected] = useState(null);
    const [section, setSection] = useState({"Id": 0, "Name": "default"});
    const currentRoom = useSelector((state) => state.rooms.currentRoom);
    const userInformation = useSelector((state) => state.user);

    const handleOpenModal = (currentSection) => {
        setSection(currentSection);
        setUpdateModal(true);
    }
    
    const handleUpdateSection = (newName) => {
        section.sectionName = newName;
        updateSection(section.id, section, sections, setSections);
    }
    
    const isOwner = () => {
        return userInformation.username === currentRoom.creatorUsername;
    }
    
    const setSectionIdToZeroIfAny = () => {
        if (sections.length > 0) {
            setSectionId(0);
        }
    }
    
    const handleDeleteSection = (row) => {
        deleteSection(row.id, setSections);
        setSectionIdToZeroIfAny();
    }

    useEffect(() => {
        setSectionIdToZeroIfAny();
    }, [currentRoom.id]);

    return (
        <>
            <TableContainer sx={RoomLayoutStyle.sectionsContainer}>
                <Table stickyHeader sx={{minWidth: 400}} aria-label="simple table">
                    <TableBody>
                        {sections.length === 0 ? (
                          <Box sx={SectionsContainerStyles.emptySectionsBox}>
                              <Typography sx={SectionsContainerStyles.noSectionsMessage}>No sections yet? Create one yourself!</Typography>
                          </Box>
                        ) : (
                          sections.map((row) => (
                            <TableRow
                              className="TableRow"
                              key={row.id}
                              sx={isSelected === row.id ? SectionsContainerStyles.sectionSelected : SectionsContainerStyles.tableBody}
                            >
                                <TableCell 
                                  sx={nameCellStyle}
                                  onMouseEnter={() => setIsHovered(row.id)}
                                  onMouseLeave={() => setIsHovered(null)}
                                  onClick={() => {
                                      setIsSelected(row.id);
                                      setSectionId(row.id);
                                  }}
                                >
                                    {"#" + row.sectionName} 
                                </TableCell>
                                  <TableCell 
                                    align="right"
                                    onMouseEnter={() => setIsHovered(row.id)}
                                    onMouseLeave={() => setIsHovered(null)}
                                    onClick={() => {
                                        setIsSelected(row.id);
                                    }}
                                  >
                                      {(isOwner() && isHovered === row.id) && (
                                          <IconButton sx={editButtonStyle} onClick={() => {
                                              handleOpenModal(row)
                                          }}>
                                              <EditIcon style={{fontSize: 25}}/>
                                          </IconButton>
                                        )}
                                      {(isOwner() && isHovered === row.id) && (
                                          <IconButton sx={deleteButtonStyle} onClick={() => handleDeleteSection(row)}>
                                                  <DeleteIcon style={{fontSize: 25}}/>
                                          </IconButton>
                                      )}
                                  </TableCell>
                            </TableRow>
                          ))
                        )}
                    </TableBody>
                </Table>
            </TableContainer>
            <UpdateSectionModal section={section} sections={sections} updateModal={updateModal}
                                setUpdateModal={setUpdateModal} updateSection={handleUpdateSection}/>
        </>
    );
};

export default SectionsContainer;