import React, { Component } from "react";
import CreateStudentReports from "./CreateStudentReports";
import { FetchStudentData } from "./FetchStudentData";

// The constructor sets the initial state of studentReports to an empty array.
export class Home extends Component {
  state = {
    studentReports: [],
  };
  constructor(props) {
    super(props);
    this.state = {
      studentReports: [],
    };
  }

  // This function is used to add a student report to the state array:
  // The handleStudentReportSubmit() method sets the state of studentReports to contain the report passed in
  // and renders two components, CreateStudentReports and FetchStudentData.
  handleStudentReportSubmit = (report) => {
    this.setState({
      studentReports: [...this.state.studentReports, report],
    });
  };

  // The CreateStudentReports component takes in the handleStudentReportSubmit and passes it as a prop
  // The FetchStudentData component renders the FetchStudentData component
  render() {
    return (
      <div>
        <CreateStudentReports onSubmit={this.handleStudentReportSubmit} />
        <FetchStudentData></FetchStudentData>
      </div>
    );
  }
}
