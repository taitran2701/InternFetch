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
          
          <Col>
            <Sidebar/>              
          </Col>
          
          <Col>
          </Col>

          <Col xs={4}>
            <Content/>
          </Col>

          <Col>
           <Sideright/>
          </Col>

        </Row>
        
      </Container>      
    </>
  )
  
}

export default Body;
