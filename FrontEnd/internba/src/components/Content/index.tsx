import React, { Fragment, useEffect, useState, useCallback } from "react";
import Card from "./Card.module.scss";
import News from "./News.module.scss";
import AddStatus from "../AddStatus";
import PostUser from "../PostUser";
import PostEmotion from "../PostEmotion";
import PostAction from "../PostAction";
import PostComment from "../PostComment";
import AddComment from "../AddComment";
import UpComment from "../PostComment";
import Modal from "../common/modal";
import UpdatePost from "../modal/updatepostmodal";
import AddPic from "../modal/attachModal";
interface IPost {
  id: string;
  content: string;
  userId: string;
}
interface IAttach {
  id: string;
  image: string;
  video: string;
}

export default function Content(this: any, props: IPost) {
  const [show, setShow] = useState(false);
  const [posts, setPosts] = useState([]);
  const [postId, setPostId] = useState<string>("");
  const [user, setUser] = useState<{ userId: string }>();
  const [updatepost, setUpdatePost] = useState<string>();
  const [attachs, setAttach] = useState<string>();

  const upPost = useCallback(() => {
    fetch("https://localhost:7076/api/Posts")
      .then((response) => response.json())
      .then((posts) => {
        console.log(posts);
        setPosts(posts);
      })
      .catch((err) => {
        ("");
        console.log(err.message);
      });
  }, []);
  useEffect(() => {
    upPost();
  }, [upPost]);

  const handleAttach = () => {
    fetch(`https://localhost:7076/api/Categories/filter?ID=${props.id}`, {
      headers: {
        "Content-type": "application/json;charset=UTF-8",
      },
    })
      .then((response) => response.json())
      .then((attachment) => {
        setAttach(attachment);
      })
      .catch((err) => {
        console.log(err.message);
      });
  };

  //Delete
  const deletePost = (id: string) => {
    fetch(`https://localhost:7076/api/Posts?id=${id}`, {
      method: "DELETE",
    }).then((response) => {
      if (response.status === 200) {
        setPosts(
          posts.filter((post: IPost) => {
            return post.id !== id;
          })
        );
      } else {
        return;
      }
    });
  };
  console.log(posts);

  return (
    <React.Fragment>
      <div>
        <div className={Card.newsCard}>
          <AddStatus upPost={upPost} />
        </div>

        <div className={Card.newsCard}>
          {posts.map((post: IPost) => {
            return (
              <React.Fragment>
                <PostUser />

                <div style={{ marginBottom: "20px" }}>
                  {/* <div>{post.id} </div> */}
                  <div className={News.newsDescription}>{post.content}</div>
                  <div className={News.newsImage}></div>
                  <div className={News.newsEmotion}>
                    <PostEmotion />
                  </div>

                  <div className={News.feedAction}>
                    <AddComment postComment={post} />
                  </div>
                  <div className={Card.deleteButton}>
                    <button
                      className="delete-btn"
                      onClick={() => deletePost(post.id)}
                    >
                      Delete
                    </button>
                    <button
                      onClick={() => setShow(true)}
                      className="update-btn"
                    >
                      Update
                    </button>
                    <UpdatePost
                      show={show}
                      onClose={() => setShow(false)}
                      id={post.id}
                      upPost={upPost}
                    />
                    {/* <button onClick={() => setShow(true)}>Attach</button>
                  <AddPic
                    show={show}
                    onClose={() => setShow(false)}
                    id={post.id}
                  /> */}
                  </div>
                </div>
              </React.Fragment>
            );
          })}
        </div>
      </div>
    </React.Fragment>
  );
}
