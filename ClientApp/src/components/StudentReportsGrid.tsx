import React from 'react';
import { Grid, GridColumn } from '@progress/kendo-react-grid';
import { StudentReport } from '../Models/StudentReport';


//MOVE THIS DATA TO BACKEND (WILL REQUIRE FORMATTING THE DATA SHAPE)
const _data: StudentReport[] = [
  { name: 'Beth', course: 'English', grade: 98 },
  { name: 'Allen', course: 'Science', grade: 83 },
  { name: 'Greg', course: 'Math', grade: 80 },
  { name: 'Bob', course: 'Art', grade: 92 },
  { name: 'Jane', course: 'History', grade: 90 },
  { name: 'John', course: 'Quantum Physics', grade: 88 }
]
const StudentReportsGrid = ({ data }) => {
  return (
    <Grid data={_data}>
      <GridColumn field="name" title="Name" />
      <GridColumn field="course" title="Course" />
      <GridColumn field="grade" title="Grade" />
    </Grid>
  )
}

export default StudentReportsGrid;
