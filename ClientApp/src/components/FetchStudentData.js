import React, { Component } from 'react';
import { records, populateStudentReports } from './DataHelper';

export class FetchStudentData extends Component {
  static displayName = FetchStudentData.name;

  constructor(props) {
    super(props);
    this.state = {studentReports: [], loading: true };
  }

  async componentDidMount() {
    await populateStudentReports();
    this.setState({ studentReports: records, loading: false });

    this.checkChanges();
  }

  // This is a hack.
  // We check if the length of the incoming records are different than the
  // Internal state (studentReports - records). If they are different, then we insert the
  // incoming records into the internal state (studentReports)
  // We check every 1.5s
  checkChanges() {
    setInterval(() => {
      if (records.length !== this.state.studentReports) {
        this.setState({ studentReports: records, loading: false });
      }
    }, 1500);
  }

  static renderStudentReportsTable(studentReports) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Name</th>
            <th>Course</th>
            <th>Grade</th>
          </tr>
        </thead>
        <tbody>
          {studentReports.map(studentReport =>
            <tr key={studentReport.name}>
              <td>{studentReport.name}</td>
              <td>{studentReport.course}</td>
              <td>{studentReport.grade}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchStudentData.renderStudentReportsTable(this.state.studentReports);

    return (
      <div>
        <h1 id="tabelLabel" >Student Reports</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async populateStudentReports() {
    const response = await fetch('api/studentreport');
    const data = await response.json();
    console.log('DATA: ', data);
    this.setState({ studentReports: data, loading: false });
  }
}
