

import "./content.scss"
function Content(){
    return (
        <>
            <div className="NewsCard">

                <div className="FeedStatus">

                    <div className="StatusWrapper">
                       <div className="Avatar">
                            <img src="https://lh3.googleusercontent.com/a-/AOh14GjznYLHNnOotz1OvIAbOggupvj7hCWNvHPm0tqG6w=s96-c" alt="" />
                       </div>                       
                       <div>
                            <div className="StatusName">Tai Tran</div>
                            <div className="StatusTime">1 days ago</div>
                       </div>
                    </div>

                    <div className="StatusMore">
                        <img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABmJLR0QA/wD/AP+gvaeTAAAAQUlEQVRIie3OMQqAMBBE0YenM3j/CyS5hxbaCsJahXmwzW9miYg1HZgYaIX+auB8rhc62L4s/q25v+rYCz0ilnEBbYAZX2fi+9QAAAAASUVORK5CYII=" alt="" />             
                    </div>

                </div>

                <div className="StatusDescription">
                    Let create our first social web
                </div>

                <div className="StatusImage">
                    <img src="https://unica.vn/media/imagesck/1604553244_Social-network-la-gi.jpg?v=1604553244" alt="" />
                </div>

                <div className="StatusReaction">
                    <div className="Status_emotion">
                        <img src="data:image/jpeg;base64,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" alt="" />
                        <span>7</span>
                    </div>
                    <div className="Status_comment">2 comments</div>
                </div>

                <div className="FeedAction">
                    <div className="FeedActionWrapper">
                        <div className="ActionState">
                            <span role="img" aria-label="like" className="anticon anticon-like emotionIcon "></span>
                        </div>
                        <div className="ActionState"></div>
                        <div className="ActionState"></div>S
                    </div>
                </div>

            </div>
            
        </>
    )
    
   
}
export default Content;