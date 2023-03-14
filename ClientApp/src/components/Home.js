import React, { Component } from "react";
import CreateStudentReports from "./CreateStudentReports";
import { FetchStudentData } from "./FetchStudentData";

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

  handleStudentReportSubmit = (report) => {
    this.setState({
      studentReports: [...this.state.studentReports, report],
    });
  };

  render() {
    return (
      <div>
        <CreateStudentReports onSubmit={this.handleStudentReportSubmit} />
        <FetchStudentData></FetchStudentData>
      </div>
    );
  }
}
