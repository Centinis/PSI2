import React from 'react';
import {Button,Paper,Table,TableRow,TableCell,TableBody,TableContainer} from '@mui/material';
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';

const SectionsContainer = ({sections, handleDelete, handleUpdate, handlePost, setSectionId}) => {
    return (
        <>

            <TableContainer component={Paper} style={{maxHeight: 300}}>
                <Table stickyHeader sx={{minWidth: 400}} aria-label="simple table">
                    <TableBody>
                        {sections.map((row) => (
                            <TableRow
                                key={row.sectionId}
                                sx={{'&:last-child td, &:last-child th': {border: 0}}}
                            >
                                <TableCell component="th" scope="row">
                                  <Button onClick={() => setSectionId(row.sectionId)}>
                                    {"#" + row.sectionName}
                                  </Button>
                                </TableCell>
                                <TableCell align="right"><Button startIcon={<DeleteIcon style={{fontSize: 30}}/>}
                                                                 onClick={() => handleDelete(row.sectionId)}></Button>
                                    <Button startIcon={<EditIcon style={{fontSize: 30}}/>}
                                            onClick={() => handleUpdate(row.sectionId)}></Button>
                                </TableCell>

                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
            <Button className={"addSec"} onClick={() => handlePost()}>add Section</Button>

        </>
    );
};

export default SectionsContainer;