import modal from "./index.module.scss";
import add from "./addStatusModal.module.scss";
import { useEffect, useState } from "react";
import Content from "../../Content";
import AddPic from "../imageModal";
import AddVid from "../videoModal";

export interface ICreatePost {
  show: boolean;
  onClose: () => void;
  content: string;
  userId: string;
  id: string;
}

export default function CreatePost(props: ICreatePost) {
  const { onClose } = props;
  const [show, setShow] = useState(false);
  const [content, setContent] = useState<string>("");
  const [userId, setUserId] = useState<string>("");
  const [posts, setPosts] = useState<string>("");
  const [id, setPostId] = useState<string>("");
  const [user, setUser] = useState<{ userId: string }>();

  useEffect(() => {
    const user = localStorage.getItem("user");
    if (user) {
      setUserId(JSON.parse(user)?.userId);
    }
  });

  const addPosts = () => {
    fetch("https://localhost:7076/api/Posts", {
      method: "POST",
      body: JSON.stringify({
        content,
        userId: userId,
      }),
      headers: {
        "Content-type": "application/json; charset=UTF-8",
      },
    })
      .then((response) => response.json())
      .then((post) => {
        setPosts(post);
        setContent(content);

        localStorage.setItem(
          "post",
          JSON.stringify({
            postId: post.id,
          })
        );
      })
      .catch((err) => {
        console.log(err.message);
      });
  };
  const handleSubmit = (e: any) => {
    e.preventDefault();
    addPosts();
    onClose();
  };
  if (!props.show) return null;
  return (
    <div className={modal.modal}>
      <div className={modal.content}>
        <div className={add.header}>
          <span> Create Post</span>
          <button className={add.closeButton} onClick={onClose}></button>
        </div>
        <div className={add.body}>
          <div className={add.user}>
            <img
              className={add.avatar}
              src="https://i.pinimg.com/736x/9b/89/2c/9b892c9c099e0c98db5bb9fe5a04d43e.jpg"
              alt=""
            />
            <div className={add.userWrapper}>
              <div className={add.userName}>Tai Tran</div>
              <button>Friend</button>
            </div>
          </div>
          <textarea
            value={content}
            onChange={(e) => setContent(e.target.value)}
            placeholder="What's on your mind?"
            className={add.textArea}
            spellCheck="false"
          ></textarea>
          <div className={add.emojiWrapper}>
            <button className={add.emoji}>
              <img
                src="https://winka-social-network.netlify.app/static/media/smile.802e4e1c.png"
                alt=""
              />
            </button>
          </div>
          <div className={add.postButton}>
            <span>Add to your post</span>
            <div className={add.buttons}>
              <button onClick={() => setShow(true)}>
                <img src="./../../../..//public/asset/img/Addpic.png" alt="" />
                <AddPic show={show} onClose={() => setShow(false)} />
              </button>

              <button onClick={() => setShow(true)}>
                <img src="./../../../..//public/asset/img/youtube.png" alt="" />
                <AddVid show={show} onClose={() => setShow(false)} />
              </button>
              <button>
                <img
                  src="./../../../..//public/asset/img/Addfriend.png"
                  alt=""
                />
              </button>
              <button>
                <img
                  src="./../../../..//public/asset/img/Location.png"
                  alt=""
                />
              </button>
            </div>
          </div>
        </div>

        <div className={add.footer}>
          <button
            className={add.createButton}
            type="submit"
            onClick={handleSubmit}
          >
            Post
          </button>
        </div>
      </div>
    </div>
  );
}
