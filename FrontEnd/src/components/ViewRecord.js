import React, { useEffect, useState, useContext } from "react";
import { Form, Container, InputGroup, Button, Col, Row } from "react-bootstrap";
import { useSelector, useDispatch } from "react-redux";
import axios from "axios";
import { BootstrapTable, TableHeaderColumn } from "react-bootstrap-table";
import { getApi, postApi } from '../redux/services'
import { getPostedRecord, getAllRecord } from '../redux/actions/actions';
import { cameraSpeedURL, postedURL } from "../utils/constant";
const ViewRecord = () => {
    const result = useSelector((state) => state);
    const dispatch = useDispatch();
    const [payloadReq, setPayload] = useState({
        orderByField: {
            fieldName: 0,
            orderBy: 0
        },
        filterByField: {
            fieldName: 0,
            filterKeyword: ""
        }
    });
    const [payloadItem, setPayloadItem] = useState({
        fieldName: "",
        orderBy: "",
        filterBy: "",
        filterKeyword: ""
    });
    const [fieldName, setFieldName] = useState([
        {
            key: '-- Select --',
            val: 0
        },
        {
            key: 'Date',
            val: 1
        },
        {
            key: 'TimeSiteInHours',
            val: 2
        },
        {
            key: 'Description',
            val: 3
        },
        {
            key: 'Camera Location',
            val: 4
        },
        {
            key: 'Street',
            val: 5
        },
        {
            key: 'Number Checked',
            val: 6
        },
        {
            key: 'Highest Speed',
            val: 7
        },
        {
            key: 'Average Speed',
            val: 8
        },
        {
            key: 'Posted Speed',
            val: 9
        }
    ]);
    const [orderType, setOrderType] = useState([
        {
            key: '-- Select --',
            val: 0
        },
        {
            key: 'Ascending',
            val: 1
        },
        {
            key: 'Descending',
            val: 2
        }
    ]);
    const [isFormShow, setFormShow] = useState(true);
    const [isLinkShow, setLinkShow] = useState(false);

    const showFormClick = (isShow) => {
        setFormShow(isShow);
        setLinkShow(!isShow);
    }

    const handleChange = (event) => {
        const value = event.target.value;
        setPayloadItem(

            {
                ...payloadItem,
                [event.target.name]: value,
            }
        );
    };

    const submitClick = () => {
        var items = {
            orderByField: {
                fieldName: parseInt(payloadItem.fieldName || 0),
                orderBy: parseInt(payloadItem.orderBy || 0)
            },
            filterByField: {
                fieldName: parseInt(payloadItem.filterBy || 0),
                filterKeyword: payloadItem.filterKeyword,
            }
        };
        setPayload(items);
        console.log("pa", items);
        fetchAllRecord(items);

    };
    const clearClick = () => {
        var items = {
            fieldName: "",
            orderBy: "",
            filterBy: "",
            filterKeyword: ""
        }
        setPayloadItem(items);
        var payload = {
            orderByField: {
                fieldName: 0,
                orderBy: 0
            },
            filterByField: {
                fieldName: 0,
                filterKeyword: '',
            }
        };
        setPayload(payload);
        fetchAllRecord(payload);
    }
    const fetchAllRecord = async (request) => {
        console.log("payloadReq", request);
        const data = await postApi(cameraSpeedURL, request).catch((err) => {
            console.log("Err", err);
        });
        dispatch(getAllRecord(data));
    }


    useEffect(() => {
        fetchAllRecord(payloadReq);
    }, []);

    //console.log("result", result);
    return (
        <div>
            <Container>
               
                <br></br>
                <br></br>
                <Form hidden={isFormShow}>
                    <Row>
                        <Col>
                            <InputGroup className="mb-3">
                                <InputGroup.Text id="basic-addon1">Order By Field</InputGroup.Text>
                                <Form.Select
                                    value={payloadItem.fieldName}
                                    onChange={handleChange}
                                    name="fieldName" >
                                    {fieldName.map(({ key, val }, index) => <option value={val} >{key}</option>)}
                                </Form.Select>
                            </InputGroup>
                        </Col>
                        <Col>
                            <InputGroup className="mb-3">
                                <InputGroup.Text id="basic-addon1">Order By Type</InputGroup.Text>
                                <Form.Select
                                    value={payloadItem.orderBy}
                                    name="orderBy"
                                    onChange={handleChange}
                                >
                                    {orderType.map(({ key, val }, index) => <option value={val} >{key}</option>)}
                                </Form.Select>
                            </InputGroup>
                        </Col>
                    </Row>
                    <Row>
                        <Col>
                            <InputGroup className="mb-3">
                                <InputGroup.Text id="basic-addon1">Filter By Field</InputGroup.Text>
                                <Form.Select
                                    value={payloadItem.filterBy}
                                    name="filterBy"
                                    onChange={handleChange}
                                >
                                    {fieldName.map(({ key, val }, index) => <option value={val} >{key}</option>)}
                                </Form.Select>
                            </InputGroup>
                        </Col>
                        <Col>
                            <InputGroup className="mb-3">
                                <InputGroup.Text id="basic-addon1">Filter Keyword</InputGroup.Text>
                                <Form.Control placeholder="Input Keyword" name="filterKeyword" value={payloadItem.filterKeyword} onChange={handleChange} />
                            </InputGroup>
                        </Col>
                    </Row>
                    <Row>
                        <Col>
                            <Button onClick={submitClick}>Submit Query</Button> &nbsp;&nbsp;&nbsp;
                            <Button onClick={clearClick}> &nbsp; Clear Query &nbsp;</Button>

                        </Col>
                        <Col style={{ textAlign: "right" }}>
                            <Button variant="link" onClick={() => showFormClick(true)}>Hide Form</Button>
                        </Col>
                    </Row>
                </Form>

                <Button variant="link" onClick={() => showFormClick(false)} hidden={isLinkShow}>&raquo;Show Order by and Filter By Criteria</Button>

                <br ></br>
                <BootstrapTable
                    data={result && result.allRecords}
                    striped
                    hover
                    pagination={true}
                >
                    <TableHeaderColumn isKey dataField='date' width="120px">Date</TableHeaderColumn>
                    <TableHeaderColumn dataField='timeatsiteinhours' width="150px">TimeAtSiteInHours</TableHeaderColumn>
                    <TableHeaderColumn dataField='description_of_site' width="300px">Description of Site</TableHeaderColumn>
                    <TableHeaderColumn dataField='camera_Location' width="150px">Camera Location</TableHeaderColumn>
                    <TableHeaderColumn dataField='street' width="300px">Street</TableHeaderColumn>
                    <TableHeaderColumn dataField='number_Checked'width="140px">Number Checked</TableHeaderColumn>
                    <TableHeaderColumn dataField='highest_Speed' width="130px">Highest Speed</TableHeaderColumn>
                    <TableHeaderColumn dataField='average_Speed' width="130px">Average Speed</TableHeaderColumn>
                    <TableHeaderColumn dataField='posted_Speed'  width="120px">Posted Speed</TableHeaderColumn>
                </BootstrapTable>
               
            </Container>

        </div>

    );
}
export default ViewRecord;