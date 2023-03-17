import React, { Component } from 'react';
import { records, populateStudentReports } from './DataHelper';

// This component exports the class FetchStudentData as part of the React component
export class FetchStudentData extends Component {
  static displayName = FetchStudentData.name;

// This constructor sets an initial state which is an empty array
// We also set a loading state to true
  constructor(props) {
    super(props);
    this.state = {studentReports: [], loading: true };
  }

// This componentDidMount event calls the static method populateStudentReports
// This method is part of the DataHelper component and is used to fetch student report data
// Once the data is fetched, the state is updated and the component renders the data
  async componentDidMount() {
    await populateStudentReports();
    this.setState({ studentReports: records, loading: false });

    this.checkChanges();
  }

// This method checks changes on the state every 1.5s's to see if the records
// array length is different than the state's studentReports length.
// If they are different, then the state's studentReports array is populated
// with the new records.
  checkChanges() {
    setInterval(() => {
      if (records.length !== this.state.studentReports) {
        this.setState({ studentReports: records, loading: false });
      }
    }, 1500);
  }

// This static method renders an HTML table that has the data from the studentReports array
// and will display it by mapping through the array.
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

// This render method will render a header and description with a table of the
// student reports data that is fetched from the server.
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

// This method fetches the student report data from the server and once it is completed
// it sets the loading state to false and sets the state with the new records
  async populateStudentReports() {
    const response = await fetch('api/studentreport');
    const data = await response.json();
    console.log('DATA: ', data);
    this.setState({ studentReports: data, loading: false });
  }
}
