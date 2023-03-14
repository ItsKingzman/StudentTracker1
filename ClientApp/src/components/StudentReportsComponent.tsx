import * as React from 'react';
import { StudentReport } from '../Models/StudentReport';

// React (Typescript) Component

export default class StudentReportsComponent extends React.Component {
  data: { name: string; course: string; grade: number }
  setState: any
  constructor(props: any) {
    super(props)
    this.data = {
      name: props.name ? props.name : '',
      course: props.course ? props.course : '',
      grade: props.grade ? props.grade : 0,
    }
  }

  handleChange = (event: React.FormEvent<HTMLInputElement>) => {
    console.log(event);
    const target = event.target as HTMLInputElement
    const name = target.name
    if (name === 'name') {
      // this.setState({ name: target.value })
      this.data.name = target.value;
    } else if (name === 'course') {
      // this.setState({ course: target.value })
      this.data.course = target.value;
    } else {
      console.log(target.value);
      // this.setState({ grade: parseInt(target.value) })
      this.data.grade = Number(target.value);
    }
  }

  handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault()
    const studentReport: StudentReport = {
      name: this.data.name,
      course: this.data.course,
      grade: this.data.grade,
    }

    //validating the input
    if (!studentReport.name || !studentReport.course || !studentReport.grade) {
      return
    }

    // this.props.onAdd(studentReport)
  }

  render() {
    return (
      <form onSubmit={this.handleSubmit}>
        <label>Name</label>
        <input
          type="text"
          name="name"
          value={this.data.name}
          onChange={this.handleChange}
        />
        <label>Course</label>
        <input
          type="text"
          name="course"
          value={this.data.course}
          onChange={this.handleChange}
        />
        <label>Grade</label>
        <input
          type="number"
          name="grade"
          value={this.data.grade}
          onChange={this.handleChange}
        />
        <input type="submit" value="Save" />
      </form>
    )
  }
}
