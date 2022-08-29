import { Col, Container, Row } from "react-bootstrap";
import Content from "../../Content";
import Sidebar from "../../Sidebar";
import Sideright from "../../Sideright";
import "./Body.scss"

function Body() {
  return (
    <>
      <Container className="bodypart">
        <Row>
          
          <Col xs={2}>
            <Sidebar/>              
          </Col>
          
          {/* <Col xs={1}> </Col> */}

          <Col xs={5}>
            <Content/>
          </Col>

          <Col xs={2}>
           <Sideright/>
          </Col>

        </Row>
        
      </Container>      
    </>
  )
  
}

export default Body;
